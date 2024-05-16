using jvargasT6.Modelo;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace jvargasT6.Vistas;

public partial class home : ContentPage
{

    private const string url = "http://127.0.0.1:80/appMovil/post.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Estudiante> estuadientes;
    public home()
    {
        InitializeComponent();
        obtener();
    }

    public async void obtener()
    {
        var content = await cliente.GetStringAsync(url);
        List<Estudiante> ListEs = JsonConvert.DeserializeObject<List<Estudiante>>(content);
        estuadientes = new ObservableCollection<Estudiante>(ListEs);
        listaEstudiantes.ItemsSource = estuadientes;
    }

    private void btnSaltar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new vAgregar());
    }

    private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var objetoestudiante = (Estudiante)e.SelectedItem;
        Navigation.PushAsync(new vActualizar(objetoestudiante));
    }
}