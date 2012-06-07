using System;
using System.Collections.Generic;
using System.Web;
using NewLife.Mvc;
using NewLife.Cube.Controllers;

/// <summary>
///Urls 的摘要说明
/// </summary>
public class Urls : IRouteConfig
{

    public void Config(RouteConfigManager cfg)
    {
        cfg.Route(
                "/Model", typeof(ModelControllerFactory),
                ""
            );
    }
}