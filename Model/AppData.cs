using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRepairing.Model
{
    public static class AppData//Связь с БД на которую потом ссылаемся почти в каждом окне приложения
    {
        public static DeviceRepairingEntities db = new DeviceRepairingEntities();
    }
}
