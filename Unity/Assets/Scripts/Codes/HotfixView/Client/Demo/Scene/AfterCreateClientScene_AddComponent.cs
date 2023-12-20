using YIUIFramework;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class AfterCreateClientScene_AddComponent: AEvent<Scene, EventType.AfterCreateClientScene>
    {
        protected override async ETTask Run(Scene scene, EventType.AfterCreateClientScene args)
        {
            if (Define.UseFGUI)
            {
                scene.AddComponent<FUIEventComponent>();
                scene.AddComponent<FUIAssetComponent, bool>(false);
                scene.AddComponent<FUIComponent>();
            }
            else
            {
                YIUIBindHelper.InternalGameGetUIBindVoFunc = YIUICodeGenerated.YIUIBindProvider.Get;
                await scene.AddComponent<YIUIMgrComponent>().Initialize();
                
                #region 根据需求自行处理
                //在editor下自动打开  也可以根据各种外围配置 或者 GM等级打开
#if UNITY_EDITOR
                scene.AddComponent<GMCommandComponent>();
#endif
                #endregion
            }
            

            scene.AddComponent<LocalizeComponent>();
            await ETTask.CompletedTask;
        }
    }
}