using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.AI.DataAccess.Abstract
{
    public interface IPromptDal
    {
        Task<string> Send(string prompt);
    }
}
