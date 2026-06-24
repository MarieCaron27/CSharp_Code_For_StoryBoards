using ObjCRuntime;

namespace storyboards;

public partial class ViewController : NSViewController
{
    protected ViewController(NativeHandle handle) : base(handle)
    {
        // This constructor is required if the view controller is loaded from a xib or a storyboard.
        // Do not put any initialization here, use ViewDidLoad instead.
    }

    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        // Do any additional setup after loading the view.
    }

    public override NSObject RepresentedObject
    {
        get => base.RepresentedObject;
        set
        {
            base.RepresentedObject = value;

            // Update the view, if already loaded.
        }
    }
    
    partial void OnButtonClicked(NSButton sender)
    {
        // 1. Votre logique métier ou validation ici
        Console.WriteLine("Utilisateur validé");

        // 2. Déclenchement de la transition programmée
        this.PerformSegue("goToProfile", this); 
    }
    
    public override void PrepareForSegue (NSStoryboardSegue segue, NSObject sender)
    {
        base.PrepareForSegue (segue, sender);

        // Take action based on Segue ID
        switch (segue.Identifier) {
            case "MyNamedSegue":
                // Prepare for the segue to happen
                NSApplication.SharedApplication.MainWindow.Title = "CLICK OK";
                break;
        }
    }
}