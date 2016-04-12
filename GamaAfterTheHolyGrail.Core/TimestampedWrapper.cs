using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaAfterTheHolyGrail.Core
{
    public class TimestampedWrapper<T> : ModelWrapper<T>, ITimestamps
    {
        public TimestampedWrapper(T model)
            : base(model)
        { }

        public DateTime? CreatedAt
        {
            get { return GetValue<DateTime?>(); }
            set { SetValue(value); }
        }

        public DateTime? UpdatedAt
        {
            get { return GetValue<DateTime?>(); }
            set { SetValue(value); }
        }

        public DateTime? RemovedAt
        {
            get { return GetValue<DateTime?>(); }
            set { SetValue(value); }
        }

        public bool IsActive
        {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }
    }
}
