public class TOKObjectController{
    private static bool pauseMovement = false;
    public static void SetPause(bool pause){
        pauseMovement = pause;
    }
    public static bool GetPause(){
        return pauseMovement;
    }
}