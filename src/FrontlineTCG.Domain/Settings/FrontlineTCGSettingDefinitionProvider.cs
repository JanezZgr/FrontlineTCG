using Volo.Abp.Settings;

namespace FrontlineTCG.Settings;

public class FrontlineTCGSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(FrontlineTCGSettings.MySetting1));
    }
}
