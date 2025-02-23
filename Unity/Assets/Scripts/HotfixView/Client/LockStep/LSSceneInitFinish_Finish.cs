namespace ET.Client
{
    [Event(SceneType.LockStep)]
    public class LSSceneInitFinish_Finish: AEvent<Scene, LSSceneInitFinish>
    {
        protected override async ETTask Run(Scene clientScene, LSSceneInitFinish args)
        {
            Room room = clientScene.GetComponent<Room>();
            
            await room.AddComponent<LSUnitViewComponent>().InitAsync();
            
            room.AddComponent<LSCameraComponent>();

            if (!room.IsReplay)
            {
                room.AddComponent<LSOperaComponent>();
            }

            room.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_LSLobby);
            await ETTask.CompletedTask;
        }
    }
}