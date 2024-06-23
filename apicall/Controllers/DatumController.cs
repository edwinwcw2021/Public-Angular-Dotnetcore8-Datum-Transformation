using Microsoft.AspNetCore.Mvc;
using datCal;
using datCal.Model;

namespace apicall.Controllers
{
  public class DatumController : Controller
  {
    [HttpPost("getAngularDatumHKGEO")]
    [ProducesResponseType(200, Type = typeof(Responsebase))]
    public IActionResult GetResult([FromForm] Requestbase req)
    {
      Responsebase res = new Responsebase();
      datum dat = new datum();
      double lat = 0, lng = 0;
      dat.HKGEO(2, req.x, req.y, ref lat, ref lng);
      res.lat = lat;
      res.lng = lng;
      //  Task.Run(async () => { rst = await dal.update(cat); });
      return Json(res);
    }

#pragma warning disable 1998
    [HttpPost("getAngularDatumGEOByHKG")]
    [ProducesResponseType(200, Type = typeof(Geo))]
    public async Task<IActionResult> GetResultGeo([FromForm] HKG req)
    {
      Geo res = new Geo();            
      double lat = 0, lng = 0;
      datum dat = new datum();
      dat.HKGEO(2, req.X, req.Y, ref lat, ref lng); 
      res.Latitude = dat.dms(lat, datum.out_format.dm);
      res.Longitude = dat.dms(lng, datum.out_format.dm);
      return Json(res);
    }
#pragma warning restore 1998


  }
}
