using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Data.Domain.Interfaces
{
    public interface IEntity
    {
        public int Id { get; set; }
        public DateTime? Updated { get; set; }

        public DateTime Added { get; set; }
    }
}
