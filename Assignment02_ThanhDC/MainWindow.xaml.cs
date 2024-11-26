using BusinessObjects;
using Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment02_ThanhDC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly int? MemberRole;
        public MainWindow()
        {
            InitializeComponent();
            this.productService = new ProductService();
            this.categoryService = new CategoryService();

        }

        public MainWindow(int? MemberRole)
        {
            InitializeComponent();
            this.productService = new ProductService();
            this.categoryService = new CategoryService();
            this.MemberRole = MemberRole;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.loadData();
        }
        
        private void loadData()
        {
            this.dgData.ItemsSource = productService.GetProducts().Select(
                p => new { p.ProductId, p.ProductName, p.CategoryId, p.UnitInStock, p.UnitPrice, p.Category }
            );

            this.cboCategory.ItemsSource = categoryService.GetCategories();
            this.cboCategory.DisplayMemberPath = "CategoryName";
            this.cboCategory.SelectedValuePath = "CategoryId";
        }


        

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
            Application.Current.Shutdown();
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row = (DataGridRow) dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            if(row != null )
            {
                DataGridCell cell = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                if(cell != null)
                {
                    string id = ((TextBlock)cell.Content).Text;
                    Product product = productService.GetProductById(Int32.Parse(id));

                    txtProductID.Text = product.ProductId.ToString();
                    txtProductName.Text = product.ProductName.ToString();
                    txtPrice.Text = product.UnitPrice.ToString();
                    txtUnitsInStock.Text = product.UnitInStock.ToString();
                    cboCategory.SelectedValue = product.CategoryId;
                    
                }
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.ProductId = Int32.Parse(txtProductID.Text);
            product.ProductName = txtProductName.Text;
            product.UnitPrice = Decimal.Parse(txtPrice.Text);
            product.UnitInStock = short.Parse(txtUnitsInStock.Text);
            product.CategoryId = Int32.Parse(cboCategory.SelectedValue.ToString());

            if (productService.AddProduct(product))
            {
                MessageBox.Show("Create Successfully.");
                this.loadData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Create Failed!!!");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.ProductId = Int32.Parse(txtProductID.Text);
            product.ProductName = txtProductName.Text;
            product.UnitPrice = Decimal.Parse(txtPrice.Text);
            product.UnitInStock = short.Parse(txtUnitsInStock.Text);
            product.CategoryId = Int32.Parse(cboCategory.SelectedValue.ToString());

            if(productService.UpdateProduct(product))
            {
                MessageBox.Show("Update Successfully.");
                this.loadData();
                cboCategory.SelectedValue = product.CategoryId;
            }
            else
            {
                MessageBox.Show("Update Failed!!!");
            }
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            var deleteProduct = string.IsNullOrEmpty(txtProductID.Text);
            if (!deleteProduct)
            {
                var result = MessageBox.Show("Are you sure you want to delete this productID?",
                                             "Confirm Delete",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {

                    if (productService.DeleteProductById(Int32.Parse(txtProductID.Text)))
                    {
                        MessageBox.Show("Delete Successful!");
                        ClearData();
                        this.loadData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the product!!!");
                    }
                }
            }
            else
            {
                MessageBox.Show("You must select a Product!!!");
            }
        }

        public void ClearData()
        {
            txtProductID.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtUnitsInStock.Text = string.Empty;
            cboCategory.SelectedIndex = -1;


        }

        
    }
}