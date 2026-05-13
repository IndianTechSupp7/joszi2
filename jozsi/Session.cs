using jozsi;
using System.Collections.ObjectModel;

public static class UserStore
{
    public static ObservableCollection<User> Users { get; }
        = new ObservableCollection<User>();
}