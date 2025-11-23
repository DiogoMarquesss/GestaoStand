using ObjetosNegocio;
using RegrasNegocio;
using System;
using System.Collections.Generic;

namespace Interface
{
    internal class GestaoStand
    {
        const int GarantiaDias = 547;//18 meses em dias
        #region Attributes
        Stand stand;
        RegrasCarros carros;
        RegrasCarrosVendidos carrosVendidos;
        RegrasClientes clientesStand;
        RegrasFunc func;
        #endregion

        #region Methods

        #region Constructors
        public GestaoStand()
        {
            carros = new RegrasCarros();
            clientesStand = new RegrasClientes();
            carrosVendidos = new RegrasCarrosVendidos();
            func = new RegrasFunc();    
            stand = new Stand();    

        }

        public GestaoStand(Stand stand)
        {
            carros = new RegrasCarros();
            clientesStand = new RegrasClientes();
            carrosVendidos = new RegrasCarrosVendidos();
            func = new RegrasFunc();
            this.stand = stand; 
        }
        #endregion

        #region Properties
        #endregion

        #region Functions
        #region Funcoes Stand
        /// <summary>
        /// Utilizada para vender um carro, coloca o carro vendido num array de carros vendidos e retira o carro do stand
        /// </summary>
        /// <param name="m">Matricula do carro vendido</param>
        /// <param name="cli">Cliente a quem o carro foi vendido</param>
        /// <returns></returns>
        public  bool VendeCarro(string m, Cliente cli, Permi p, out int CdErro)
        {
            CdErro = 0;
            int aux = carros.TentaEncontarCarro(m);
            if (aux < 0) return false;
            Carro carroaux = carros.TentaEncontrarQualCarro(m, out CdErro);
            Cliente cli2 = clientesStand.TentaEncontarObjCliente(cli.IdCliente, out CdErro);
            if (cli2 == null)
            {
                clientesStand.TenteaCriarAdiconaNovoCLiente(cli.IdCliente,cli.Nome,cli.Ncc,cli.Telemovel, p, out CdErro);
                carros.TenteAlterarIdCliente(cli.IdCliente, m, p);
                string auxd2 = carroaux.Data.ToString();
                carrosVendidos.TentaCriarAdicionarCarroVendido(carroaux.Matricula, auxd2, carroaux.Preco,carroaux.Marca,carroaux.Combustivel, p, out CdErro);
                carros.TentaRemoverCarro(m, p);
                return true;
            }
            carroaux.IdCliente = cli.IdCliente;
            string auxd = carroaux.Data.ToString();
            carrosVendidos.TentaCriarAdicionarCarroVendido(carroaux.Matricula, auxd, carroaux.Preco, carroaux.Marca, carroaux.Combustivel, p, out CdErro);
            carros.TentaRemoverCarro(m, p);
            return true;
        }

        /// <summary>
        /// Verifica se um carro vendido ainda tem garantia
        /// </summary>
        /// <param name="m">Matricula do carro</param>
        /// <returns></returns>
        private  bool VerificaGarantia(string m, Permi p, out int e)
        {
            int carroaux = carrosVendidos.TentaEncontarCarroVendido(m, p);
            if (carroaux < 0)
            {
                e = -132;
                return false;
            }
            DateTime aux = carrosVendidos.TentaVerificarDataVenda(m, p, out e);
            System.DateTime date1 = aux;//data de venda
            System.DateTime date2 = DateTime.Now;
            System.TimeSpan diff1 = date2.Subtract(date1);
            if (diff1.Days <= GarantiaDias)
            {
                e = -999;
                return true;
            }
            e = -999;
            return false;
        }
        #region Ficheiros
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileCarros"></param>
        /// <param name="fileCarrosVend"></param>
        /// <param name="clientes"></param>
        /// <returns></returns>
        public  bool GuardaDadosStand(string fileCarros, string fileCarrosVend, string clientes, string fileFunc, string fileErros)
        {
            carros.TentaGuardarCarros(fileCarros);
            clientesStand.TentaGuardarClientes(clientes);
            carrosVendidos.TentaGuardarCarrosVendidos(fileCarrosVend);
            func.TentaGuardarFuncionarios(fileFunc);
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileCarros"></param>
        /// <param name="fileCarrosVend"></param>
        /// <param name="clientes"></param>
        /// <returns></returns>
        public  bool LeDadosStand(string fileCarros, string fileCarrosVend, string clientes, string fileFunc, Permi p)
        {
            carros.TentaLerFicheiroCarros(fileCarros);
            clientesStand.TentaLerFicheiroClientes(clientes);
            carrosVendidos.TentaLerFicheiroClientes(fileCarrosVend);
            func.TentaLerFicheiroFuncionarios(fileFunc, p);
            return true;
        }
        #endregion 
        #endregion

        #region Carros
        /// <summary>
        /// Insere um carro no Stand
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <param name="CdErro"></param>
        /// <returns></returns>
        public  int InsereCarroStand(Carro c, Permi p, out int CdErro)
        {
            string aux = c.Data.ToString();
            int a =carros.TentaCriarAdicionarCarro(c.Matricula,aux,c.Preco,c.Marca,c.Combustivel,p,out CdErro);
            return a;
        } 

        /// <summary>
        /// Remove um Carro do Stand
        /// </summary>
        /// <param name="m"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public  int RemoveCarroStand(string m, Permi p)
        {
            int a = carros.TentaRemoverCarro(m, p);
            return a;
        }

        /// <summary>
        /// Lista todos os carros do Stand
        /// </summary>
        /// <returns></returns>
        public  string[] ListaCarrosStand()
        {
            string[] aux = ListaCarrosStand();
            return aux;
        }

        /// <summary>
        /// Atraves da matricula diz qual a marca do carro associado a ela
        /// </summary>
        /// <param name="m">matricula</param>
        /// <param name="e">erro</param>
        /// <returns></returns>
        public  string QualMarcaCarro(string m, out int e)
        {
            string aux = carros.QualMarca(m, out e);
            return aux;
        }

        /// <summary>
        /// Atraves da matricula diz qual o ano do carro associado a ela
        /// </summary>
        /// <param name="m">matricula</param>
        /// <param name="e"></param>
        /// <returns></returns>
        public  DateTime QualAData(string m, out int e)
        {
            DateTime aux = carros.QualDataCarro(m, out e);
            return aux;
        }
        /// <summary>
        /// Atraves da matricula diz qual o preco do carro associado a ela
        /// </summary>
        /// <param name="m">matricula</param>
        /// <returns></returns>
        public  int QualPreco(string m)
        {
            int a = carros.QualPrecoCarro(m);
            return a;
        }

        /// <summary>
        /// Verifica se existe um carro no stand
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public  int ExisteCarro(string m)
        {
            int a = carros.TentaEncontarCarro(m);
            return a;
        }

        #endregion

        #region Clientes
        /// <summary>
        /// Remove um cliente da lista do stand
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <param name="p">permissao</param>
        /// <returns></returns>
        public  int RemoveCliente(int id, Permi p)
        {
            int a = clientesStand.TentaRemoverCliente(id, p);
            return a;
        }

        /// <summary>
        /// Tenta listar todos os clientes do stand
        /// </summary>
        /// <returns></returns>
        public  List<int> ListaClientes()
        {
            List<int> a = clientesStand.TentaListarClientes();
            return a;
        }

        /// <summary>
        /// Da o nome do cliente associado a um determinado id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  string QualNomeCliente(int id)
        {
            string aux = clientesStand.TentaVerNome(id);
            return aux;
        }
        
        /// <summary>
        /// Diz qual o telemovel associado a um cliente atraves do id de cliente
        /// </summary>
        /// <param name="id">id cliente</param>
        /// <param name="p">permissao</param>
        /// <returns>devolve o numero de cliente</returns>
        public  int QualTelemovelCliente(int id, Permi p)
        {
            int aux = clientesStand.TentaVerTelemovel(id,p);
            return aux;
        }

        #endregion

        #region CarrosVendidos
        /// <summary>
        /// Lista todos os carros vendidos pelo o Stand
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public  List<string> ListaCarrosVendidos(out int e)
        {
            List<string> aux =carrosVendidos.TentaListarCarrosVendidos(out e);
            return aux;

        }
        /// <summary>
        /// Remove um carro do dicionario de carros vendidos do stand
        /// </summary>
        /// <param name="m">matricula do carro a ser removido</param>
        /// <param name="p">permissao</param>
        /// <returns></returns>
        public  int RemoveCarroVendidoStand(string m, Permi p)
        {
            int aux = carrosVendidos.TentaEncontarCarroVendido(m,p);
            return aux;
        }

        /// <summary>
        /// Procuar  a data de venda de um carro vendido pelo o stand
        /// </summary>
        /// <param name="m">matricula</param>
        /// <param name="p">permissao</param>
        /// <param name="e">errro</param>
        /// <returns></returns>
        public  DateTime DataVendaCarro(string m, Permi p, out int e)
        {
            DateTime aux = carrosVendidos.TentaVerificarDataVenda(m, p, out e);
            return aux;
        }
        #endregion CarrosVendidos

        #region Funcionarios
        /// <summary>
        /// Lista todos os funcionarios do stand
        /// </summary>
        /// <returns></returns>
        public  List<int> ListaTodosFuncionarios()
        {
            List<int> aux = func.ListaFuncionario();
            return aux;
        }

        /// <summary>
        /// Adiciona um novo funcionario ao Stand
        /// </summary>
        /// <param name="funci">Objeto do tipo funcionario</param>
        /// <param name="p">permissao</param>
        /// <param name="e">erro</param>
        /// <returns></returns>
        public  int AdicionaFuncionario(Funcionario funci, Permi p, out int e)
        {
            int a = func.TentaCriarAdicionarFunc(funci.IdFuncionario, funci.IdStand, funci.Nome, p, out e);
            return a;
        }

        /// <summary>
        /// Remove um funcionario do stand
        /// </summary>
        /// <param name="id"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public  int RemoveFuncionario(int id, Permi p)
        {
            int a = func.TentaRemoverFuncionario(id, p);
            return a;
        }
        /// <summary>
        /// Procura o nome de um funcionario atraves do id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public  string QualNomeFuncionario(int id, out int e)
        {
            string aux = func.TentaEncontrarQualFuncionario(id,out e);
            return aux;
        }
        
        /// <summary>
        /// Verifica se um determinado funcionario existe no stand
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  int ExisteFuncionario(int id)
        {
            int a = func.TentaEncontarFuncionario(id);
            return a;
        }


        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ErrosCarros"></param>
        /// <param name="ErrosClientes"></param>
        /// <param name="ErrosFun"></param>
        /// <param name="ErrosCarrosVen"></param>
        /// <returns></returns>
        public int GuardaErros(string ErrosCarros, string ErrosClientes, string ErrosFun, string ErrosCarrosVen)
        {
            carros.TentaCriarLogs(ErrosCarros);
            clientesStand.TentaCriarLogsClientes(ErrosClientes);
            func.TentaCriarLogsClientes(ErrosFun);
            carrosVendidos.TentaCriaLogs(ErrosCarrosVen);
            return 1;
        }

        #endregion
        #region Overrides
        #endregion
        #endregion
    }
}

