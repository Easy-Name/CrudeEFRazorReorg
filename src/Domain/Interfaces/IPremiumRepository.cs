using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPremiumRepository : IBaseRepository<Premium>
    {

    }
}

//as interfaces são como se fossem o contrato do método que herda elas. Se o método que herda ela não tiver o método da interface, dará erro


