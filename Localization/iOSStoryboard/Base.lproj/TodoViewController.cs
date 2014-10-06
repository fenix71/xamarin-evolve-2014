// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace LionTodo
{
	public partial class TodoViewController : UITableViewController
	{
		public TodoViewController (IntPtr handle) : base (handle)
		{
		}

		public Todo currentTodo { get; set; }
		public TodoListViewController Delegate {get;set;}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			SaveButton.TouchUpInside += (sender, e) => {
				currentTodo.Title = TitleText.Text;
				currentTodo.Notes = NotesText.Text;
				currentTodo.Done = DoneSwitch.On;
				AppDelegate.Current.TodoDB.Save(currentTodo);
				NavigationController.PopToRootViewController(true);
			};
			DeleteButton.TouchUpInside += (sender, e) => {
				AppDelegate.Current.TodoDB.Delete(currentTodo);
				NavigationController.PopToRootViewController(true);
			};
		}

		// this will be called before the view is displayed 
		public void SetTask (TodoListViewController d, Todo todo) {
			Delegate = d;
			currentTodo = todo;
		}
		// when displaying, set-up the properties
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			TitleText.Text = currentTodo.Title;
			NotesText.Text = currentTodo.Notes;
			DoneSwitch.On = currentTodo.Done;
		}
	}
}