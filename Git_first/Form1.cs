using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
/*****************************************************************
 *  Molecular Weight Calculator 

  Wonhyuk Cho
 * Revision History: 
 *        - 2/8/22 `project created`
 *                 `added namespaces for REGEX and elements txt file in this project`
 *        - 2/9/22 `inserting elements to datagridview is working` 
 *        - 2/9/22 `added LINQ sorting for each button and successed`
 *        - 2/10/22`added Regex Calculate mass, total mass changing label color when the textchanged`
 *        - 2/14/22`fixed errors after more testing`
 * purpose : The assignment is to create a molar mass calculator. Given a chemical formula, the molar mass
 *           calculator will produce the sum of the atomic weights for each atom in the formula times its occurrence.

 * Tested chemical formula:
 *        - Valid : C8H10N4O2, C6HN3O8Pb, UO2, C6H6N4O4, FeLiO4P, BBr3
 *        - Invalid : HHH20CCc(Cc - matched with pattern, but not in the list), H2147483648 (exceed int max)
 * ***************************************************************/

namespace Git_first
{
    public partial class Form1 : Form
    {
        // binding source relays data to and from the data aware control
        BindingSource _bs = new BindingSource();
        // list of elements
        List<Element> _lstElem = new List<Element>();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load1;
        }

        private void Form1_Load1(object sender, EventArgs e)
        {
            //form text as Group D
            this.Text = "LINGQ MMC Group D";
            UI_btn_sortByName.Text = "Sort By Name";
            UI_btn_sortByAtomic.Text = "Sort By Atomic #";
            UI_btn_single.Text = "Single Character Symbols";
            UI_lbl_cFor.Text = "Chemical Formula:";
            UI_lbl_mass.Text = "Approx. Molar Mass:";
            UI_lbl_massVal.Text = "0";

            // binding source to DGV
            UI_DataGridView.DataSource = _bs;
            // auto fill DGV
            UI_DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // hide rowheader
            UI_DataGridView.RowHeadersVisible = false;

            UI_btn_sortByName.Click += UI_btn_sortByName_Click;
            UI_btn_single.Click += UI_btn_single_Click;
            UI_btn_sortByAtomic.Click += UI_btn_sortByAtomic_Click;
            UI_tbox_formula.TextChanged += UI_tbox_formula_TextChanged;

            // read element informations from txt file
            TextFileReader(@"../../Elements/Elements.txt");
        }

        public void TextFileReader(string path)
        {
            // use try catch block to catch unexpected error during reading a text file
            try
            {
                // generate StreamReader 
                StreamReader _Sr = new StreamReader(path);

                // string array to store element informations
                string[] _sInfo;

                // read file line by line until it contains "SourceLink"
                while (!(_sInfo = _Sr.ReadLine()?.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)).Contains("SourceLink"))
                    _lstElem.Add(new Element(_sInfo)); // add new element to the list 
            }
            catch (FileNotFoundException ex)
            {
                // show error on the output panel
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                // show error on the output panel
                Console.WriteLine(ex.Message);
            }
        }

        private void UI_tbox_formula_TextChanged(object sender, EventArgs e)
        {
            // string for the chemical formula typed by user
            string sFormula = UI_tbox_formula.Text;

            // generate new regex to specify words that matched with specific pattern
            // 1. word that is starting with an upper case letter + lowercase letters as group of 'symbol'
            // 2. word that is any number of digits as group of 'count'
            Regex reg = new Regex(@"(?'symbol'[A-Z][a-z]?)(?'count'\d+)?");

            // dictionary with Key = element symbol as string / Value = element count as int
            Dictionary<string, int> _dElemInfo = new Dictionary<string, int>();

            // check if there is word that matched with pattern
            if (reg.IsMatch(sFormula))
            {
                // collect matched words
                MatchCollection x = reg.Matches(sFormula);

                // iterate through matched collection
                foreach (Match gp in x)
                {
                    // convert symbol value to string
                    string sSymbol = gp.Groups["symbol"].ToString();

                    // int for symbol's count
                    int iCount = 0;

                    // use try catch for catching the exception when the count is over max of int
                    try
                    {
                        // convert count value to int
                        // set default value of count as 1 if count value is not provided
                        iCount = gp.Groups["count"].ToString() == "" ? 1 : int.Parse(gp.Groups["count"].ToString());
                    }
                    catch (Exception err)
                    {
                        // show error on the output panel
                        Console.WriteLine(err);
                        // show message to user
                        MessageBox.Show("Count must be less than 2147483647");
                        UI_tbox_formula.Text = "";
                        break;
                    }

                    // if symbol is already exist in the dictionary then increase it's count
                    // otherwise, insert new Key and Value to dictionary
                    if (_dElemInfo.ContainsKey(sSymbol))
                        _dElemInfo[sSymbol] += iCount;
                    else
                        _dElemInfo[sSymbol] = iCount;
                }
            }

            // find symbol that exist in element list by using join
            var result = from ElemFormula in _dElemInfo
                         join elem in _lstElem
                         on ElemFormula.Key equals elem.symbol
                         orderby elem.Atomic ascending
                         select new { Element = elem.name, Count = ElemFormula.Value, Mass = Math.Round(elem.Mass, 3), TotalMass = Math.Round(elem.Mass * ElemFormula.Value, 3) };

            // clear datasource
            _bs.DataSource = null;
            // assign new datasource
            _bs.DataSource = result;

            // H H H20 C Cc (Cc is matched with pattern but not in the element list - error)
            // show diffrenet color for Molar Mass
            // 1. check if result count and matched count are identical
            // 2. check if all text in formula matches with regex pattern
            if (result.Count() != _dElemInfo.Keys.Count || Regex.Replace(sFormula, reg.ToString(), "").Length > 0)
                // if chemical formula has error then set color as red
                UI_lbl_massVal.ForeColor = Color.Red;
            else if (UI_tbox_formula.Text == "")
                // if chemical formula is empty then set color as black
                UI_lbl_massVal.ForeColor = Color.Black;
            else
                // if chemical formula has no error then set color as green
                UI_lbl_massVal.ForeColor = Color.Green;

            // calculate and set the Molar Mass to 4 decimal point and show with unit
            UI_lbl_massVal.Text = (from i in result select i.TotalMass).Sum().ToString("F4") + " g/mol";

            // align text in DGV cells
            DGV_Formula_setup(result);
        }

        private void UI_btn_sortByAtomic_Click(object sender, EventArgs e)
        {
            //Linq type that grabs all the element in our list and order them by their Atomic Number in Ascending.
            _bs.DataSource = from elem in _lstElem
                             orderby elem.Atomic ascending
                             select new { AtomicNumber = elem.Atomic, Name = elem.name, Symbol = elem.symbol, Mass = elem.Mass.ToString("F4") };
            // align text for DGV cells
            DGV_setup();
        }

        private void UI_btn_single_Click(object sender, EventArgs e)
        {
            //Linq type that grabs all the Elements in our list and order them by name in Ascending.
            _bs.DataSource = from elem in _lstElem
                             where elem.symbol.Length == 1
                             orderby elem.Atomic ascending
                             select new { AtomicNumber = elem.Atomic, Name = elem.name, Symbol = elem.symbol, Mass = elem.Mass.ToString("F4") };
            // align text in DGV cells
            DGV_setup();
        }

        private void UI_btn_sortByName_Click(object sender, EventArgs e)
        {
            // Linq type that grabs all the Elements in our list and order them by name in Ascending.
            _bs.DataSource = from elem in _lstElem
                             orderby elem.name ascending
                             select new { AtomicNumber = elem.Atomic, Name = elem.name, Symbol = elem.symbol, Mass = elem.Mass.ToString("F4") };
            // align text in DGV cells
            DGV_setup();
        }
        public void DGV_setup()
        {
            UI_DataGridView.Columns[0].HeaderText = "Atomic #";
            UI_DataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            UI_DataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            UI_DataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            UI_DataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        /// <summary>
        /// modify text of mass column to Total Mass
        /// aligning text for each columns
        /// </summary>
        public void DGV_Formula_setup<T>(IEnumerable<T> result)
        {
            // aligning text for each column when there is any valid result
            if (result.Count() > 0)
            {
                UI_DataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                UI_DataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                UI_DataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                UI_DataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                UI_DataGridView.Columns[3].HeaderText = "Total Mass";
            }
        }
    }
}
