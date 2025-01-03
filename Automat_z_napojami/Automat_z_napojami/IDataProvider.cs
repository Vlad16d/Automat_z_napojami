using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automat_z_napojami
{
    public interface IDataProvider
    {
        List<Product> LoadProducts();
        void SaveProducts(List<Product> products);
    }
}
