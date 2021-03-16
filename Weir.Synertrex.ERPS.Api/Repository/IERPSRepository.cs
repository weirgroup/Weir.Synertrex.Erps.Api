using System.Collections.Generic;
using Weir.Synertrex.ERPS.Api.Model;

namespace Weir.Synertrex.ERPS.Api.Repository
{
    public interface IERPSRepository
    {
        List<DeviceTwin> GetDeviceTwinsData();
    }
}