using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoruxBot.SDK.Plugins.Ability;
using SoruxBot.SDK.Plugins.Basic;
using SoruxBot.SDK.Plugins.Model;

namespace SoruxBot.QQjsonconvert.Plugins;

public class Register : SoruxBotLib
{
    public override string GetLibName() => "QQjsonconvert";

    public override string GetLibVersion() => "1.0.0";

    public override string GetLibAuthorName() => "Open SoruxBot Project";

    public override string GetLibDescription() => "这是一个QQjsonconvert Lib";

    public override LibType GetLibType() => LibType.SdkLib;
}

