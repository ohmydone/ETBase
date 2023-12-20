namespace ET.Client
{
    [Event(SceneType.Current)]
    public class AfterCreateCurrentScene_AddComponent: AEvent<Scene, EventType.AfterCreateCurrentScene>
    {
        protected override async ETTask Run(Scene scene, EventType.AfterCreateCurrentScene args)
        {
            if (Define.UseFGUI)
            {
                scene.AddComponent<FUIComponent>();
            }
            else
            {
                
            }
            
            await ETTask.CompletedTask;
        }
    }
}