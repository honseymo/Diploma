using Doc_Builder.ClassesForGenerate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Doc_Builder
{
    /// <summary>
    /// Логика взаимодействия для DocumentGeneration.xaml
    /// </summary>
    public partial class DocumentGeneration : Window
    {
        private string _type;
        private string _fullName = "";
        public bool create=false;
        public DocumentGeneration(string type)
        {
            InitializeComponent();
            User10_Sgr1Entities conn = new User10_Sgr1Entities();
            Employers.ItemsSource = conn.MIL_Employees.ToList();
            _type = type;
            switch (type)
            {
                case "Акт об оказании услуг":
                    this.Title = "Акт об оказании услуг";
                    AKTBLANK.Visibility = Visibility.Visible;
                    break;
                case "Приказ об увольнении":
                    this.Title = "Приказ об увольнении";
                    DissmisalBlank.Visibility = Visibility.Visible;
                    break;
                case "Приказ об приеме на работу":
                    this.Title = "Приказ об приеме на работу";
                    BlankPriema.Visibility = Visibility.Visible;
                    break;
                case "Заявление на прием":
                    this.Title = "Заявление на прием";
                  WorkDocument.Visibility = Visibility.Visible;
                    break;
                case "Заявление на вычет сотрудника":
                    this.Title = "Заявление на вычет сотрудника";
                    VICHET.Visibility = Visibility.Visible;
                    break;
                case "Платёжная ведомость":
                    this.Title = "Платёжная ведомость";
                    PLAT_VEDOMOST.Visibility = Visibility.Visible;
                    break;
                case "Заявление Возврат НДФЛ":
                    this.Title = "Заявление Возврат НДФЛ";
                    VOZVRAT_NDFL.Visibility = Visibility.Visible;
                    break;
                default:
                    
                   break;
              }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            create = true;
            var helper = new WordHelper("Documents/Templates/BlankOprieme.doc");
            var items = new Dictionary<string, string>
            {
                {"<ORG>", ORG.Text},
                {"<FIO>", FIO.Text},
                {"<PROF>", PROF.Text},
                {"<DATE_FROM>", DATEFROM.Text},
                {"<MONTHS>", MONTHS.Text},
                {"<SALARY>", SALARY.Text},
                {"<DATE>", DATE.Text},
            };
            helper.Process(items, _type, _fullName);
            this.Close();
            
        }

        private void New_employer(object sender, RoutedEventArgs e)
        {
            create = true;
            var helper = new WordHelper("Documents/Templates/BlankPriema.docx");
            var items = new Dictionary<string, string>
            {
                {"<ORG>", ORG_Emp.Text},
                {"<NUMBER>", Number_Emp.Text},
                {"<DATE>", Date_Emp.Text},
                {"<DATE_FROM>", DATEFROM_Emp.Text},
                {"<DATE_FOR>", DATEFOR_Emp.Text},
                {"<FIO>", FIO_Emp.Text},
                {"<NUNMERIC_TABEL>", NUNMERIC_TABEL_Emp.Text},
                {"<TYPE>", TYPE_Emp.Text},
                {"<PROF>", PROF_Emp.Text},
                {"<NAME_OF_PROF>", NAME_OF_PROF_Emp.Text},
                {"<SALARY>", SALARY_Emp.Text},
                {"<ALLOWANCE>", ALLOWANCE_Emp.Text},
                {"<PROBATION>", PROBATION_Emp.Text},
                {"<NUM_TREATY>", NUM_TREATY_Emp.Text},
                {"<PROF_HEAD>", PROF_HEAD_Emp.Text},
            };
            helper.Process(items, _type, _fullName);
            this.Close();
            
        }

        private void New_Dissmis(object sender, RoutedEventArgs e)
        {
            create = true;
            var helper = new WordHelper("Documents/Templates/BlankObUvolnenie.doc");
            var items = new Dictionary<string, string>
            {
                {"<ORG>", ORG_Dis.Text},
                {"<NUMBER>", NUMBER_DIS.Text},
                {"<DATE>", DATE_DIS.Text},
                {"<DATE_DOC>", DATE_DOC_DIS.Text},
                {"<NUMBER_DOC>", NUMBER_DOC.Text},
                {"<DATE_UVOL>", DATE_UVOL_DIS.Text},
                {"<NUNMERIC_TABEL>", NUNMERIC_TABEL_DIS.Text},
                {"<FIO>", FIO_DIS.Text},
                {"<TYPE>", TYPE_DIS.Text},
                {"<PROF>", PROF_DIS.Text},
                {"<BASE>", BASE_DIS.Text},
                {"<DOCUMENT_FOUNDATION>", DOCUMENT_FOUNDATION_DIS.Text},
                {"<PROF_HEAD>", PROF_HEAD_DIS.Text},
            };
            helper.Process(items, _type, _fullName);
            this.Close();
            
        }

        private void New_Act(object sender, RoutedEventArgs e)
        {
            create = true;
            var helper = new WordHelper("Documents/Templates/Akt.docx");
            var items = new Dictionary<string, string>
            {
                {"<NUMBER>", NUMBER_ACT.Text},
                {"<DATE>", DATE_ACT.Text},
                {"<EXECUTOR>", EXECUTOR_ACT.Text},
                {"<CUSTOMER>", CUSTOMER_ACT.Text},
                {"<BASE>", BASE_ACT.Text},
                {"<TITLEWORKS>", TITLEWORKS_ACT.Text},
                {"<QUANTITY>", QUANTITY_ACT.Text},
                {"<UNITS>", UNITS_ACT.Text},
                {"<COST>", COST_ACT.Text},
                {"<SUM>", SUM_ACT.Text},
                {"<NDS>", NDS_ACT.Text},
            };
            helper.Process(items, _type, _fullName);
            this.Close();
            
        }

        private void New_Plat_Vedomost(object sender, RoutedEventArgs e)
        {
            create = true;
            var helper = new WordHelper("Documents/Templates/Plat_Vedomost.RTF");
            var items = new Dictionary<string, string>
            {
                {"<ORG>", ORG_PLAT_VEDOMOST.Text},
                {"<TYPE>", TYPE_PLAT_VEDOMOST.Text},
                {"<KOR_NUMBER>", KOR_NUMBER_PLAT_VEDOMOST.Text},
                {"<DATE_FROM>", DATE_FROM_PLAT_VEDOMOST.Text},
                {"<DATE_FOR>", DATE_FOR_PLAT_VEDOMOST.Text},
                {"<SUM>", SUM_PLAT_VEDOMOST.Text},
                {"<PROF_HEAD>", PROF_HEAD_PLAT_VEDOMOST.Text},
                {"<DATE>", DATE_PLAT_VEDOMOST.Text},
                {"<NUMBER>", NUMBER_PLAT_VEDOMOST.Text},
                {"<DATE_FROM_RAS>", DATE_FROM_RAS_PLAT_VEDOMOST.Text},
                {"<DATE_FOR_RAS>", DATE_FOR_RAS_PLAT_VEDOMOST.Text},
            };
            helper.Process(items, _type, _fullName);
            this.Close();
            
        }

        private void New_Vichet(object sender, RoutedEventArgs e)
        {
            create = true;
            var helper = new WordHelper("Documents/Templates/StandartVichet.rtf");
            var items = new Dictionary<string, string>
            {
                {"<ORG>", ORG_VICHET.Text},
                {"<PROF_HEAD>", PROF_HEAD_VICHET.Text},
                {"<FIO>", FIO_VICHET.Text},
                {"<PASSPORT_NUMBER>", PASSPORT_NUMBER_VICHET.Text},
                {"<PASSPORT_DATE>", PASSPORT_DATE_VICHET.Text},
                {"<DATE_BIRTH>", DATE_BIRTH_VICHET.Text},
                {"<ADDRES>", ADDRES_VICHET.Text},
                {"<ROLE>", ROLE_VICHET.Text},
                {"<SUM_VICHET>", SUM_VICHET.Text},
                {"<NUMBER>", NUMBER_VICHET.Text},
                {"<FIO_CHILDREN>", FIO_CHILDREN_VICHET.Text},
                {"<YEAR>", YEAR_VICHET.SelectedDate.ToString()},
                {"<EDUCATE_PLACE>", EDUCATE_PLACE_VICHET.Text},
                {"<DATE>", DATE_VICHET.Text},
            };
            helper.Process(items, _type, _fullName);
            this.Close();
           
        }

        private void New_VOZVRAT(object sender, RoutedEventArgs e)
        {
            create = true;
            var helper = new WordHelper("Documents/Templates/VozvratNDFL.doc");
            var items = new Dictionary<string, string>
            {
                {"<NUMBER_INSPECT>", NUMBER_INSPECT_VOZVRAT.Text},
                {"<DATE_FORM>", DATE_FORM_VOZVRAT.Text},
                {"<ADDRES_INSPECT>", ADDRES_INSPECT_VOZVRAT.Text},
                {"<INN>", INN_VOZVRAT.Text},
                {"<YEAR>", YEAR_VOZVRAT.Text},
                {"<REASON>", REASON_VOZVRAT.Text},
                {"<SUM>", SUM_VOZVRAT.Text},
                {"<NUMBER>", NUMBER_VOZVRAT.Text},
                {"<NAME_BANK>", NAME_BANK_VOZVRAT.Text},
                {"<ADDRES_BANK>", ADDRES_BANK_VOZVRAT.Text},
                {"<REQUSITES>", REQUSITES_VOZVRAT.Text},
                {"<DATE>", DATE_VOZVRAT.Text},
            };
            helper.Process(items, _type, _fullName);
            this.Close();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            User10_Sgr1Entities conn = new User10_Sgr1Entities();
            MIL_Employees employer = new MIL_Employees();
            employer = (MIL_Employees)Employers.SelectedItem;
            Mil_Templates type = conn.Mil_Templates.Where(c => c.Header == _type).FirstOrDefault();
            switch (_type)
            {
                case "Приказ об увольнении":
                    FIO_DIS.Text = employer.FullName;
                    TYPE_DIS.Text = type.TypeName;
                    PROF_DIS.Text = employer.Profession;
                    _fullName = employer.FullName;
                    break;
                case "Приказ об приеме на работу":
                    FIO_Emp.Text = employer.FullName;
                    TYPE_Emp.Text = type.TypeName;
                    PROF_Emp.Text = employer.Profession;
                    _fullName = employer.FullName;
                    break;
                case "Заявление на прием":
                    FIO.Text = employer.FullName;
                    PROF.Text = employer.Profession;
                    _fullName = employer.FullName;
                    break;
                case "Заявление на вычет сотрудника":
                    FIO_VICHET.Text = employer.FullName;
                    DATE_BIRTH_VICHET.Text = Convert.ToString(employer.DateOfBirth);
                    ROLE_VICHET.Text = employer.Profession;
                    _fullName = employer.FullName;
                    break;
                default:
                    
                    break;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (create == true)
            {
                MessageBox.Show("Успешно создан", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
