using FrontlineTCG.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FrontlineTCG.Permissions;

public class FrontlineTCGPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(FrontlineTCGPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(FrontlineTCGPermissions.MyPermission1, L("Permission:MyPermission1"));
        myGroup.AddPermission("Modify_Cards");
        myGroup.AddPermission("Modify_Abilities");
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<FrontlineTCGResource>(name);
    }
}
