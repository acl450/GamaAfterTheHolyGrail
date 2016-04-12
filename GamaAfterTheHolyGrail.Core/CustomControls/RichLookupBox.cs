using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace GamaAfterTheHolyGrail.Core.CustomControls
{
    public enum SearchMode
    {
        Delayed,
        Instant,
    }

    public class RichLookupBox : TextBox
    {

        public static DependencyProperty LabelTextProperty =
            DependencyProperty.Register(
                "LabelText",
                typeof(string),
                typeof(RichLookupBox));

        public static DependencyProperty LabelTextColorProperty =
            DependencyProperty.Register(
                "LabelTextColor",
                typeof(Brush),
                typeof(RichLookupBox));

        public static DependencyProperty SearchModeProperty =
            DependencyProperty.Register(
                "SearchMode",
                typeof(SearchMode),
                typeof(RichLookupBox),
                new PropertyMetadata(SearchMode.Delayed));

        private static DependencyPropertyKey HasTextPropertyKey =
            DependencyProperty.RegisterReadOnly(
                "HasText",
                typeof(bool),
                typeof(RichLookupBox),
                new PropertyMetadata());

        public static DependencyProperty HasTextProperty = HasTextPropertyKey.DependencyProperty;

        static RichLookupBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(RichLookupBox),
                new FrameworkPropertyMetadata(typeof(RichLookupBox)));
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            
            HasText = Text.Length != 0;

            if (SearchMode == SearchMode.Delayed)
            {
                searchEventDelayTimer.Stop();
                searchEventDelayTimer.Start();
            }
        }

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public Brush LabelTextColor
        {
            get { return (Brush)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public SearchMode SearchMode
        {
            get { return (SearchMode)GetValue(SearchModeProperty); }
            set { SetValue(SearchModeProperty, value); }
        }

        public bool HasText
        {
            get { return (bool)GetValue(HasTextProperty); }
            private set { SetValue(HasTextPropertyKey, value); }
        }

        private static DependencyPropertyKey IsMouseLeftButtonDownPropertyKey =
            DependencyProperty.RegisterReadOnly(
                "IsMouseLeftButtonDown",
                typeof(bool),
                typeof(RichLookupBox),
                new PropertyMetadata());

        public static DependencyProperty IsMouseLeftButtonDownProperty =
            IsMouseLeftButtonDownPropertyKey.DependencyProperty;


        public bool IsMouseLeftButtonDown
        {
            get { return (bool)GetValue(IsMouseLeftButtonDownProperty); }
            private set { SetValue(IsMouseLeftButtonDownPropertyKey, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            Border iconBorder = GetTemplateChild("PART_SearchIconBorder") as Border;
            if (iconBorder != null)
            {
                iconBorder.MouseLeftButtonDown += new MouseButtonEventHandler(IconBorder_MouseLeftButtonDown);
                iconBorder.MouseLeftButtonUp += new MouseButtonEventHandler(IconBorder_MouseLeftButtonUp);
                iconBorder.MouseLeave += new MouseEventHandler(IconBorder_MouseLeave);
            }

            popup = Template.FindName("PART_Popup", this) as Popup;
            listBox = Template.FindName("PART_ListBox", this) as ListBox;
            if (listBox != null)
            {
                listBox.PreviewMouseDown += new MouseButtonEventHandler(listBox_MouseUp);
                listBox.KeyDown += new KeyEventHandler(listBox_KeyDown);

                OnItemsSourceChanged(ItemsSource);
                OnItemTemplateChanged(ItemTemplate);
                OnItemContainerStyleChanged(ItemContainerStyle);
                OnItemTemplateSelectorChanged(ItemTemplateSelector);

                if (filter != null)
                    listBox.Items.Filter = FilterFunc;
            }
        }

        private void IconBorder_MouseLeftButtonDown(object obj, MouseButtonEventArgs e)
        {
            IsMouseLeftButtonDown = true;
        }


        private void IconBorder_MouseLeftButtonUp(object obj, MouseButtonEventArgs e)
        {
            if (!IsMouseLeftButtonDown) return;

            if (HasText && SearchMode == SearchMode.Delayed)
            {
                this.Text = "";
            }
            if (HasText && SearchMode == SearchMode.Instant)
            {
                RaiseSearchEvent();
            }

            IsMouseLeftButtonDown = false;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {

            if (e.Key == Key.Escape && SearchMode == SearchMode.Delayed)
            {
                this.Text = "";
            }
            else if ((e.Key == Key.Return || e.Key == Key.Enter) && SearchMode == SearchMode.Instant)
            {
                RaiseSearchEvent();
            }
            else {
                base.OnKeyDown(e);
            }
        }

        private void IconBorder_MouseLeave(object obj, MouseEventArgs e)
        {

            IsMouseLeftButtonDown = false;
        }

        public static readonly RoutedEvent SearchEvent =
            EventManager.RegisterRoutedEvent(
                "Search",
                RoutingStrategy.Direct,
                typeof(RoutedEventHandler),
                typeof(RichLookupBox));

        private void RaiseSearchEvent()
        {
            RoutedEventArgs args = new RoutedEventArgs(SearchEvent);
            RaiseEvent(args);
        }

        public static DependencyProperty SearchEventTimeDelayProperty =
        DependencyProperty.Register(
            "SearchEventTimeDelay",
            typeof(Duration),
            typeof(RichLookupBox),
            new FrameworkPropertyMetadata(
                new Duration(new TimeSpan(0, 0, 0, 0, 500)),
                new PropertyChangedCallback(OnSearchEventTimeDelayChanged)));

        public Duration SearchEventTimeDelay
        {
            get { return (Duration)GetValue(SearchEventTimeDelayProperty); }
            set { SetValue(SearchEventTimeDelayProperty, value); }
        }

        static void OnSearchEventTimeDelayChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var stb = o as RichLookupBox;
            if (stb != null)
            {
                stb.searchEventDelayTimer.Interval = ((Duration)e.NewValue).TimeSpan;
                stb.searchEventDelayTimer.Stop();
            }
        }

        private DispatcherTimer searchEventDelayTimer;
        public RichLookupBox() : base() {
            searchEventDelayTimer = new DispatcherTimer();
            searchEventDelayTimer.Interval = SearchEventTimeDelay.TimeSpan;
            searchEventDelayTimer.Tick += new EventHandler(OnSeachEventDelayTimerTick);
        }


        void OnSeachEventDelayTimerTick(object o, EventArgs e)
        {
            searchEventDelayTimer.Stop();

            InternalOpenPopup();

            RaiseSearchEvent();

            if (suppressEvent) return;
            textCache = Text ?? "";

            if (popup != null && textCache == "")
            {
                InternalClosePopup();
            }
            else if (listBox != null)
            {
                if (filter != null)
                    listBox.Items.Filter = FilterFunc;

                if (popup != null)
                {
                    if (listBox.Items.Count == 0)
                        InternalClosePopup();
                    else
                        InternalOpenPopup();
                }
            }
        }


        public event RoutedEventHandler Search
        {
            add { AddHandler(SearchEvent, value); }
            remove { RemoveHandler(SearchEvent, value); }
        }
      
        Popup popup;
        ListBox listBox;
        Func<object, string, bool> filter;
        string textCache = "";
        bool suppressEvent = false;

        FrameworkElement dummy = new FrameworkElement();

        public Func<object, string, bool> Filter
        {
            get
            {
                return filter;
            }
            set
            {
                if (filter != value)
                {
                    filter = value;
                    if (listBox != null)
                    {
                        if (filter != null)
                            listBox.Items.Filter = FilterFunc;
                        else
                            listBox.Items.Filter = null;
                    }
                }
            }
        }

        #region ItemsSource Dependency Property

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsSource.  
        // This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            ItemsControl.ItemsSourceProperty.AddOwner(
                typeof(RichLookupBox),
                new UIPropertyMetadata(null, OnItemsSourceChanged));

        private static void OnItemsSourceChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RichLookupBox actb = d as RichLookupBox;
            if (actb == null) return;
            actb.OnItemsSourceChanged(e.NewValue as IEnumerable);
        }

        protected void OnItemsSourceChanged(IEnumerable itemsSource)
        {
            if (listBox == null) return;
            Debug.Print("Data: " + itemsSource);
            if (itemsSource is ListCollectionView)
            {
                listBox.ItemsSource = new LimitedListCollectionView(
                    (IList)((ListCollectionView)itemsSource).SourceCollection)
                {
                    Limit = MaxCompletions
                };
                Debug.Print("Was ListCollectionView");
            }
            else if (itemsSource is CollectionView)
            {
                listBox.ItemsSource = new LimitedListCollectionView(((CollectionView)itemsSource).SourceCollection) { Limit = MaxCompletions };
                Debug.Print("Was CollectionView");
            }
            else if (itemsSource is IList)
            {
                listBox.ItemsSource = new LimitedListCollectionView((IList)itemsSource) { Limit = MaxCompletions };
                Debug.Print("Was IList");
            }
            else
            {
                if (itemsSource == null)
                    itemsSource = new List<string>();
                listBox.ItemsSource = new LimitedCollectionView(itemsSource) { Limit = MaxCompletions };
                Debug.Print("Was IEnumerable");
            }
            if (listBox.Items.Count == 0) InternalClosePopup();
        }

        #endregion

        #region Binding Dependency Property

        public string Binding
        {
            get { return (string)GetValue(BindingProperty); }
            set { SetValue(BindingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Binding.  
        // This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BindingProperty =
            DependencyProperty.Register(
                "Binding",
                typeof(string),
                typeof(RichLookupBox),
                new UIPropertyMetadata(null));

        #endregion

        //#region Actual Dependency Property

        //public ProyectoWrapper Actual
        //{
        //    get { return (ProyectoWrapper)GetValue(ActualProperty); }
        //    set { SetValue(ActualProperty, value); }
        //}

        //public static readonly DependencyProperty ActualProperty =
        //    DependencyProperty.Register(
        //        "Actual",
        //        typeof(ProyectoWrapper),
        //        typeof(RichLookupBox),
        //        new UIPropertyMetadata(null));

        //#endregion

        #region ItemTemplate Dependency Property

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemTemplate. 
        // This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemTemplateProperty =
            ItemsControl.ItemTemplateProperty.AddOwner(
                typeof(RichLookupBox),
                new UIPropertyMetadata(null, OnItemTemplateChanged));

        private static void OnItemTemplateChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RichLookupBox actb = d as RichLookupBox;
            if (actb == null) return;
            actb.OnItemTemplateChanged(e.NewValue as DataTemplate);
        }

        private void OnItemTemplateChanged(DataTemplate p)
        {
            if (listBox == null) return;
            listBox.ItemTemplate = p;
        }

        #endregion

        #region ItemContainerStyle Dependency Property

        public Style ItemContainerStyle
        {
            get { return (Style)GetValue(ItemContainerStyleProperty); }
            set { SetValue(ItemContainerStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemContainerStyle. 
        // This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemContainerStyleProperty =
            ItemsControl.ItemContainerStyleProperty.AddOwner(
                typeof(RichLookupBox),
                new UIPropertyMetadata(null, OnItemContainerStyleChanged));

        private static void OnItemContainerStyleChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RichLookupBox actb = d as RichLookupBox;
            if (actb == null) return;
            actb.OnItemContainerStyleChanged(e.NewValue as Style);
        }

        private void OnItemContainerStyleChanged(Style p)
        {
            if (listBox == null) return;
            listBox.ItemContainerStyle = p;
        }

        #endregion

        #region MaxCompletions Dependency Property

        public int MaxCompletions
        {
            get { return (int)GetValue(MaxCompletionsProperty); }
            set { SetValue(MaxCompletionsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxCompletions. 
        // This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxCompletionsProperty =
            DependencyProperty.Register(
                "MaxCompletions",
                typeof(int),
                typeof(RichLookupBox),
                new UIPropertyMetadata(int.MaxValue));

        #endregion

        #region ItemTemplateSelector Dependency Property

        public DataTemplateSelector ItemTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(ItemTemplateSelectorProperty); }
            set { SetValue(ItemTemplateSelectorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemTemplateSelector.  
        // This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemTemplateSelectorProperty =
            ItemsControl.ItemTemplateSelectorProperty.AddOwner(
                typeof(RichLookupBox),
                new UIPropertyMetadata(null, OnItemTemplateSelectorChanged));

        private static void OnItemTemplateSelectorChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RichLookupBox actb = d as RichLookupBox;
            if (actb == null) return;
            actb.OnItemTemplateSelectorChanged(e.NewValue as DataTemplateSelector);
        }

        private void OnItemTemplateSelectorChanged(DataTemplateSelector p)
        {
            if (listBox == null) return;
            listBox.ItemTemplateSelector = p;
        }

        #endregion

        private void InternalClosePopup()
        {
            if (popup != null)
                popup.IsOpen = false;
        }

        private void InternalOpenPopup()
        {
            popup.IsOpen = true;
            if (listBox != null) listBox.SelectedIndex = -1;
        }

        public void ShowPopup()
        {
            if (listBox == null || popup == null) InternalClosePopup();
            else if (listBox.Items.Count == 0) InternalClosePopup();
            else InternalOpenPopup();
        }

        private void SetTextValueBySelection(object obj, bool moveFocus)
        {
            if (popup != null)
            {
                InternalClosePopup();
                Dispatcher.Invoke(new Action(() => {
                    Focus();
                    if (moveFocus)
                        MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                }), System.Windows.Threading.DispatcherPriority.Background);
            }

            #region Binding binding
            // Retrieve the Binding object from the control.
            var originalBinding = BindingOperations.GetBinding(this, BindingProperty);
            if (originalBinding == null) return;

            // Set the dummy's DataContext to our selected object.
            dummy.DataContext = obj;

            // Apply the binding to the dummy FrameworkElement.
            BindingOperations.SetBinding(dummy, TextProperty, originalBinding);
            suppressEvent = true;

            // Get the binding's resulting value.
            Text = dummy.GetValue(TextProperty).ToString();
            #endregion

            //Actual = (ProyectoWrapper)obj;

            #region Actual binding

            #endregion

            suppressEvent = false;
            listBox.SelectedIndex = -1;
            SelectAll();
        }

        private bool FilterFunc(object obj)
        {
            return filter(obj, textCache);
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            if (suppressEvent) return;
            if (popup != null)
            {
                InternalClosePopup();
            }
        }
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            var fs = FocusManager.GetFocusScope(this);
            var o = FocusManager.GetFocusedElement(fs);
            if (e.Key == Key.Escape)
            {
                InternalClosePopup();
                Focus();
            }
            else if (e.Key == Key.Down)
            {
                if (listBox != null && o == this)
                {
                    suppressEvent = true;
                    listBox.Focus();
                    suppressEvent = false;
                }
            }
        }

        void listBox_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is ListBoxItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            if (dep == null) return;
            var item = listBox.ItemContainerGenerator.ItemFromContainer(dep);
            if (item == null) return;
            SetTextValueBySelection(item, false);
        }
        void listBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
                SetTextValueBySelection(listBox.SelectedItem, false);
            else if (e.Key == Key.Tab)
                SetTextValueBySelection(listBox.SelectedItem, true);
        }
    }
}
