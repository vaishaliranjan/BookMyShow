using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ControllerInterface
{
    public interface IDeleteById
    {
        bool Delete(int deleteEventId);
    }
}
