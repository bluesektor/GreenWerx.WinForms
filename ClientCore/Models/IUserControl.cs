using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using greenwerx.Models;

namespace ClientCore.Models
{
    public interface IUserControl
    {
        void Save(INode n);

        void Delete(INode n);
    }
}
