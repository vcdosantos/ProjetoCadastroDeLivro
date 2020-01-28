using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaBCC.DAL
{
    public class ConexaoOracle
    {
        public string conectarOracle()
        {
            string _StringConnectionOra = "Data Source=(DESCRIPTION = " +
                                                            "(ADDRESS = (PROTOCOL = TCP)(HOST = dboracle)(PORT = 1521)) " +
                                                            "(CONNECT_DATA = " +
                                                                "(SERVER = DEDICATED) " +
                                                                "(SERVICE_NAME = siga) " +
                                                            ") " +
                                                           ");" +
                                                "User Id=ACESSODOTNET;Password=StUx886;connection timeout=22";
            
            return _StringConnectionOra;
        }
    }
}
