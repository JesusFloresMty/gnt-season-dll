using MetaQuotes.MT5WebAPI;
using Seasons.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seasons.Metatrader
{
    class ConectMT5
    {
        private MT5WebAPI m_WebApi;

        public MT5WebAPI conect(Conector c)
        {
            MTRetCode code;
            MT5WebAPI.EnPumpModes MTPumps;
            MT5WebAPI.EnCryptModes MTCrypt;
            MTPumps = 0;
            MTCrypt = (MT5WebAPI.EnCryptModes)1;
            m_WebApi = new MT5WebAPI();
            if ((code = m_WebApi.Connect(c.server, c.port, c.login, c.password,
                             MTPumps, MTCrypt, Convert.ToInt32(c.timeout))) != MTRetCode.MT_RET_OK)
                return m_WebApi;
            return m_WebApi;
        }
    }
}
