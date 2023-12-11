using Plugin.Maui.Audio;

namespace AnimeCatalog.ViewModels;
public class AudioViewModel
{
    private readonly IAudioManager audioManager;
    private IAudioPlayer player;

    public AudioViewModel()
    {
        audioManager = new AudioManager();
    }

    public async Task PlayAudioAsync(string audioFileName)
    {
        if (player == null)
        {
            player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(audioFileName));
        }
        player.Play();
    }
}
