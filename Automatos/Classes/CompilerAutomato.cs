using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Automatos.Forms;
using System.Collections;
using System.Threading;

namespace Automatos.Classes
{
    class CompilerAutomato
    {
        #region Variáveis

        TransitionMatrix[,] transitionMatrix = new TransitionMatrix[50, 50];
        TransitionMatrix[,] newTransitionmatrix = new TransitionMatrix[50, 50];
        StatesMatrix[] stateMatrix = new StatesMatrix[50];
        ArrayList statesƐ = new ArrayList();
        ArrayList statesMoviment = new ArrayList();
        
        private int[] IndiceMatriz = new int[50];
        private int[] newIndiceMatriz = new int[50];

        StateInicial stateInicial = new StateInicial();
        StateFinal[] stateFinal = new StateFinal[50];
        
        ComponentAutomato component;

        TypeNewTransition typeNewTransition;
        public TypeNewTransition getTypeNewTransition { get { return typeNewTransition; } set { typeNewTransition = value; } }        

        public ArrayList totalStates = new ArrayList();
        
        private int[] indiceStatesFinais = new int[50];
        private int countMatrix = 0;
        private int countIndice = 0;
        private int state1 = -1, state2 = -1;
        private int nroStateAtual = -1;
        private int nroStateTrans = -1;
        private bool statesFinais = false;
        private bool build = false;
        private string nameStateTransition;
        public bool anime = false, animeInicial = false, animeTransInicial = false, animeState = false, animeTrans = false, compiler = false;
        private ArrayList TreeCompiler = new ArrayList();
        private char[] valueAnimation = new char[200];
        

        #endregion

        #region Construtor
        public CompilerAutomato(ComponentAutomato _component)
        {
            component = _component;
            for (int i = 0; i < 50; i++)
            {
                IndiceMatriz[i] = -1;
                indiceStatesFinais[i] = -1;
            }
        }
        public CompilerAutomato()
        {
        }

        #endregion

        #region Armazenamento das Informações

        #region Sets

        #region States
        public void setState1(int _State)
        {
            state1 = _State;
        }
        public void setState2(int _State)
        {
            state2 = _State;
        }
        #endregion

        #region StateInicial
        public void setStateInicial(bool _Inicial)
        {
            stateInicial.getStateInicial = _Inicial;
        }
        public void setStateInicialLocation(Point _LocationStateInicial)
        {
            stateInicial.getStateLocation = _LocationStateInicial;
        }
        public void setNameStateInicial(string _NameStateInicial)
        {
            stateInicial.getNameState = _NameStateInicial;
        }
        public void setNumberStateInicial(int _numberState)
        {
            stateInicial.getNumberState = _numberState;
        }

        #endregion

        #region StateFinal
        public void setNameStateFinal(int _numberState, string _nameState)
        {
            for (int i = 0; i < 50; i++)
            {
                if (indiceStatesFinais[i] == _numberState)
                {
                    stateFinal[indiceStatesFinais[i]].getNameState = _nameState;
                }
            }
        }
        #endregion

        #endregion

        #region Gets
        public ComponentAutomato getFindComponent()
        {
            return component;
        }
        public int getState1()
        {
            return state1;
        }
        public int getState2()
        {
            return state2;
        }
        public TransitionMatrix getFindMatrix()
        {
            return transitionMatrix[state1, state2];
        }
        public int findValueMatrixAFD(int _StateInicial, string _value)
        {
            for (int i = 0; i < 50; i++)
            {
                if (transitionMatrix[_StateInicial, i] != null)
                {
                    if (transitionMatrix[_StateInicial, i].stateValueTransition == _value)
                    {
                        return transitionMatrix[_StateInicial, i].numberStateDestino;
                    }
                }
            }
            return -1;
        }
        public ArrayList findStateDestinoMatrix(int _StateInicial)
        {
            ArrayList states = new ArrayList();

            for (int i = 0; i < 50; i++)
            {
                if (transitionMatrix[_StateInicial, i] != null)
                {
                    states.Add(transitionMatrix[_StateInicial, i].numberStateDestino);
                }
            }
            return states;
        }
        public bool getExistTransition()
        {
            return IndiceMatriz[0] != -1? true: false;
        }

        #region StateIncial
        public bool getExistStateInicial()
        {
            return stateInicial.getStateInicial;
        }
        public Point setStateInicialLocation()
        {
            return stateInicial.getStateLocation;
        }
        public string getNameStateIncial()
        {
            return stateInicial.getNameState;
        }
        public int getNumberStateInicial()
        {
            return stateInicial.getNumberState;
        }
        #endregion

        #region StateFinal
        public bool getFindExistsStateFinal(int _numberState)
        {
            for (int i = 0; i < 50; i++)
            {
                if (indiceStatesFinais[i] == _numberState)
                {
                    return true;
                }
            }
            return false;
        }
        public string getFindNameStateFinal(int _numberState)
        {
            int indice = 0;
            for (int i = 0; i < 50; i++)
            {
                if (indiceStatesFinais[i] == _numberState)
                {
                    indice = indiceStatesFinais[i];
                }
            }
            return stateFinal[indice].getNameState;
        }
        
        public bool getExistStatesFinais()
        {
            return statesFinais;
        } 
        #endregion

        #endregion

        #region Array de States
        #region Procura nome existente de estados
        public bool existsNameState(string _nameState)
        {
            for (int i = 0; i < totalStates.Count; i++)
            {
                if (totalStates[i].ToString() == _nameState)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region Renomeia os nomes dos estados
        public void renameStatesArray(string _nameState, string _nameStateAntigo)
        {
            for (int i = 0; i < totalStates.Count; i++)
            {
                if (totalStates[i].ToString() == _nameStateAntigo)
                {
                    totalStates[i] = _nameState;
                }
            }
        }
        #endregion

        #region Deleta o elemento do array
        public void deletaStateArray(string _nameState)
        {
            for (int i = 0; i < totalStates.Count; i++)
            {
                if (totalStates[i].ToString() == _nameState)
                {
                    totalStates.RemoveRange(i, 1);
                }
            }
        }
        #endregion
        #endregion

        #region Novo EstadoFinal
        public void createStateFinal(string _NameStateFinal = "", int _numberState = -1)
        {
            bool indice = false;

            if (_numberState != -1)
            {
                indice = getFindExistsStateFinal(_numberState);

                if (!indice)
                {
                    for (int i = 0; i < 50; i++)
                    {
                        if (indiceStatesFinais[i] == -1)
                        {
                            indiceStatesFinais[i] = _numberState;
                            break;
                        }
                    }
                    stateFinal[_numberState] = new StateFinal();
                    stateFinal[_numberState].getNameState = _NameStateFinal;
                    stateFinal[_numberState].getNumberState = _numberState;
                    stateFinal[_numberState].getStateFinal = true;
                    stateFinal[_numberState].getStateLocation = new Point(0, 0);
                    statesFinais = true;
                }
                else
                {
                    for (int i = 0; i < 50; i++)
                    {
                        if (indiceStatesFinais[i] == _numberState)
                        {
                            deleteIndiceStatesFinais(i);
                            break;
                        }
                    }

                    stateFinal[_numberState] = null;
                    component.getImageState(_numberState).deleteDrawFinal();

                    if (indiceStatesFinais[0] == -1)
                        statesFinais = false;
                }
            }
        }
        public void deleteStatesFinais(int _numberState)
        {
            for (int i = 0; i < 50; i++)
            {
                if (indiceStatesFinais[i] == _numberState)
                {
                    deleteIndiceStatesFinais(i);
                    break;
                }
            }

            stateFinal[_numberState] = null;
            component.getImageState(_numberState).deleteDrawFinal();

            if (indiceStatesFinais[0] == -1)
                statesFinais = false;
        }
        private void deleteIndiceStatesFinais(int i)
        {
            if (indiceStatesFinais[i + 1] != -1)
            {
                int swap = indiceStatesFinais[i];
                indiceStatesFinais[i] = indiceStatesFinais[i + 1];
                indiceStatesFinais[i + 1] = swap;
                deleteIndiceStatesFinais(i + 1);
            }
            else
            {
                indiceStatesFinais[i] = -1;
            }
        }
        #endregion

        #region Nova Transição matriz
        public void newTransition(string _ValueTransition, Label _StateLabelTransition, TypeAutomato _typeAutomato)
        {
            bool indice = false;

            for (int i = 0; i < 50; i++)
            {
                if (IndiceMatriz[i] == state1)
                {
                    indice = true;
                    break;
                }
            }            
            if(!indice)
            {
                IndiceMatriz[countIndice] = state1;
                countIndice++;
            }            

            transitionMatrix[state1, state2] = new TransitionMatrix(component.getFindIndex());
            transitionMatrix[state1, state2].stateTypeAutomato = component.typeAutomatoDesenv;
            transitionMatrix[state1, state2].numberStateOrigem = state1;
            transitionMatrix[state1, state2].numberStateDestino = state2;
            transitionMatrix[state1, state2].stateTypeAutomato = _typeAutomato;
            
            transitionMatrix[state1, state2].doubleTransition = false;

            if (transitionMatrix[state2, state1] != null && transitionMatrix[state2, state1].stateTypeTransition == TypeTransition.Line)
            {
                transitionMatrix[state1, state2].doubleTransition = true;
                transitionMatrix[state1, state2].stateDoubleTransition = TypeDoubleTransition.Down;

                transitionMatrix[state2, state1].doubleTransition = true;
                transitionMatrix[state2, state1].stateDoubleTransition = TypeDoubleTransition.Up;
                transitionMatrix[state2, state1].locationStateLabelTransition();
            }

            transitionMatrix[state1, state2].stateLocationOrigem = component.getImageState(state1).getLocationImage();
            transitionMatrix[state1, state2].stateLocationDestino = component.getImageState(state2).getLocationImage();
            transitionMatrix[state1, state2].stateValueTransition = _ValueTransition;                                                               
            transitionMatrix[state1, state2].stateLabelTransition = _StateLabelTransition;
                                                                
            transitionMatrix[state1, state2].stateNameOrigem = component.getImageState(state1).getNameAutomato();
            transitionMatrix[state1, state2].stateNameDestino = component.getImageState(state2).getNameAutomato();
        }
        #endregion

        #region Verifica transições
        public bool findExistTransition()
        {
            return transitionMatrix[state2, state1] != null ? false : true;
        }
        #endregion

        #region Find Value Matrix
        public string getValueTransition()
        {
            return transitionMatrix[state1, state2].stateValueTransition;
        }
        #endregion

        #region Deleta Elemento Matriz
        public void deleteElementMatrix(int _numberStateOrigem, int _numberStateDestino = -1)
        {
            if (_numberStateDestino == -1)
            {
                for (int i = 0; i < 50; i++)
                {
                    if (IndiceMatriz[i] == _numberStateOrigem)
                    {
                        deleteIndice(i);
                        break;
                    }
                }

                for (int j = 0; j < 50; j++)
                {
                    if (transitionMatrix[_numberStateOrigem, j] != null)
                    {
                        component.deleteStateLabelTransition(transitionMatrix[_numberStateOrigem, j].stateLabelTransition);
                        transitionMatrix[_numberStateOrigem, j] = null;
                    }
                }

                for (int j = 0; j < 50; j++)
                {
                    if (transitionMatrix[j, _numberStateOrigem] != null)
                    {
                        component.deleteStateLabelTransition(transitionMatrix[j, _numberStateOrigem].stateLabelTransition);
                        transitionMatrix[j, _numberStateOrigem] = null;
                    }
                }

                DrawTransition();
            }
            else
            {
                transitionMatrix[_numberStateOrigem, _numberStateDestino].stateLabelTransition = null;
                DrawTransition();
            }            
        }
        private void deleteIndice(int i)
        {
            if (IndiceMatriz[i + 1] != -1)
            {
                int swap = IndiceMatriz[i];
                IndiceMatriz[i] = IndiceMatriz[i + 1];
                IndiceMatriz[i + 1] = swap;
                
                deleteIndice(i + 1);
            }
            else
            {
                IndiceMatriz[i] = -1;
                countIndice--;
            }
        }
        #endregion

        #region Valida matriz
        public bool validateMatrix()
        {
            if (transitionMatrix[state1, state2] != null)
            {
                getTypeNewTransition = TypeNewTransition.FindTransition;
                return true;
            }
            getTypeNewTransition = TypeNewTransition.NewTransition;
            return false;
        }
        #endregion

        #region Transition Null
        public void nullTransition()
        {
            state1 = -1;
            state2 = -1;
        }
        #endregion

        #region Desenha Transições
        public void DrawTransition()
        {
            component.bmp = new Bitmap(1000, 1000);

            for (int i = 0; i < 50; i++)
            {
                if (IndiceMatriz[i] != -1)
                {
                    int indice = IndiceMatriz[i];
                    for (int j = 0; j < 50; j++)
                    {
                        if (transitionMatrix[indice, j] != null)
                        {
                            component.DrawTransition(transitionMatrix[indice, j].stateLocationOrigem,
                                                     transitionMatrix[indice, j].stateLocationDestino,
                                                     transitionMatrix[indice, j].stateLabelTransition,
                                                     transitionMatrix[indice, j].stateTypeTransition,
                                                     transitionMatrix[indice, j].stateDoubleTransition,
                                                     Color.Black);
                        }
                    }                                      
                }
                else
                {
                    component.nullDrawTransition();
                    break;
                }
            }
            if(stateInicial.getNumberState != -1)
                component.drawStateInicial(stateInicial.getStateLocation);
           
            component.addImagePainelAutomato();
        }
        #endregion

        #region Rename StateMatriz
        public void renameStateTransitions(int _numberState, string _name)
        {            
            if (IndiceMatriz[0] != -1)
            {
                for (int i = 0; i < 50; i++)
                {
                    if (IndiceMatriz[i] != -1)
                    {
                        for (int j = 0; j < 50; j++)
                        {
                            if (transitionMatrix[i, j] != null)
                            {
                                if (transitionMatrix[i, j].numberStateOrigem == _numberState)
                                {
                                    transitionMatrix[i, j].stateNameOrigem = _name;
                                }
                                if (transitionMatrix[i, j].numberStateDestino == _numberState)
                                {
                                    transitionMatrix[i, j].stateNameDestino = _name;
                                }
                            }
                        }
                    }
                }
            }             
        }
        #endregion

        #region Apaga os labels da transicao
        public void apagaLabels()
        {
            for (int i = 0; i < 50; i++)
            {
                if (IndiceMatriz[i] != -1)
                {
                    int indice = IndiceMatriz[i];
                    for (int j = 0; j < 50; j++)
                    {
                        if (transitionMatrix[indice, j] != null)
                        {
                            component.deleteStateLabelTransition(transitionMatrix[indice, j].stateLabelTransition);
                        }
                    }
                }
            }
        }
        #endregion

        #region Verifica se ja existe estados com a mesma transição
        public bool existAFND(int _state1, string _value)
        {
            bool origem = false;
            string valueTrans = "";
            ;

            for (int i = 0; i < 50; i++)
            {
                if (IndiceMatriz[i] == _state1)
                {
                    origem = true;
                    break;
                }
            }
            if (origem)
            {
                for (int i = 0; i < 50; i++)
                {
                    if (transitionMatrix[_state1, i] != null)
                    {
                        valueTrans = transitionMatrix[_state1, i].stateValueTransition;

                        for (int j = 0; j < valueTrans.Length; j++)
                        {
                            for (int k = 0; k < _value.Length; k++)
                            {
                                if (valueTrans[j] == _value[k])
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        #endregion

        #endregion
        
        #region Compilador

        #region Cancela/Fechar Compilador
        public void cancelaCompiler()
        {
            component.getFindIndex().lbDefinicoes.Items.Clear();

            clearArrayAnime();
            clearStateMatrix();
            animeTrans = false;
            animeState = false;
            animeInicial = false;
            animeTransInicial = false;
            build = false;

            nroStateAtual = -1;
        }
        #endregion
        
        #region Inicia Compilação
        #region init Compiler
        public void initCompiler()
        {            
            component.getFindIndex().lbDefinicoes.Items.Add("M=" + rescueStates() + "" + rescueValuesTransicao() + "δ, " + getNameStateIncial() + ", " + rescueStatesFinais() + "};" );
            initLabelsTransition();
        }
        private void initLabelsTransition()
        {
            string stateO, stateD;
            int indice = -1;
            ArrayList stateOD = new ArrayList();

            for (int i = 0; i < 50; i++)
            {
                if (IndiceMatriz[i] != -1)
                {
                    indice = IndiceMatriz[i];

                    for (int j = 0; j < 50; j++)
                    {
                        if (transitionMatrix[indice, j] != null)
                        {
                            stateO = transitionMatrix[indice, j].stateNameOrigem;
                            stateD = transitionMatrix[indice, j].stateNameDestino;

                            foreach (char c in transitionMatrix[indice, j].stateValueTransition.ToCharArray())
                                stateOD.Add(c);

                            for (int k = 0; k < stateOD.Count; k++)
                            {
                                string aux = "δ= (" + stateO + ", " + stateOD[k].ToString() + ")= " + stateD + " ;";
                                component.getFindIndex().lbDefinicoes.Items.Add(aux);
                            }
                            stateOD.Clear();
                        }
                    }
                }
            }
            
        }
        #endregion
                
        #region resgata os estados finais
        public string rescueStatesFinais()
        {
            string nameStatesFinais = "{";

            ArrayList statesFinais = new ArrayList();

            for (int i = 0; i < 50; i++)
            {
                if (indiceStatesFinais[i] != -1)
                {
                    statesFinais.Add(stateFinal[indiceStatesFinais[i]].getNameState);                    
                }
                else
                {
                    break;
                }
            }

            statesFinais.Sort();

            for (int i = 0; i < statesFinais.Count; i++)
            {
                nameStatesFinais += statesFinais[i].ToString();
                nameStatesFinais += ",";
            }

            nameStatesFinais = nameStatesFinais.Remove(nameStatesFinais.Length - 1);
            nameStatesFinais += "}";

            return nameStatesFinais;
        }
        #endregion

        #region resgata os estados
        private string rescueStates()
        {            
            string nameStates = "{";            
           
            totalStates.Sort();

            for (int i = 0; i < totalStates.Count; i++)
            {
                nameStates += totalStates[i].ToString();
                nameStates += ",";
            }
            nameStates = nameStates.Remove(nameStates.Length - 1);
            nameStates += "},";
            
            return nameStates;
        }
        #endregion

        #region resgata os valores das transições
        private string rescueValuesTransicao()
        {
            ArrayList valuesTxt = new ArrayList();

            string valuesTransition = "";

            for (int i = 0; i < 50; i++)
            {
                if (IndiceMatriz[i] != -1)
                {
                    int indice = IndiceMatriz[i];

                    for (int j = 0; j < 50; j++)
                    {
                        if (transitionMatrix[indice, j] != null)
                        {
                            valuesTransition += transitionMatrix[indice, j].stateValueTransition;
                        }
                    }
                }
            }

            foreach (char c in valuesTransition.ToCharArray())
                valuesTxt.Add(c);

            valuesTxt.Sort();

            string anterior = valuesTxt[0].ToString();

            for (int i = 1; i < valuesTxt.Count; i++)
            {
                string atual = valuesTxt[i].ToString();

                if (atual == anterior)
                {
                    valuesTxt.RemoveAt(i);
                    i--;
                }
                else
                {
                    anterior = atual;
                }
                
            }

            valuesTransition = "{";
            for (int i = 0; i < valuesTxt.Count; i++)
            {
                valuesTransition += valuesTxt[i].ToString();
                valuesTransition += ",";
            }
            valuesTransition = valuesTransition.Remove(valuesTransition.Length - 1);
            valuesTransition += "},";

            return valuesTransition;
        }
        #endregion
        #endregion

        #region Update Matriz Transições
        public void updateMatrixTransitions(int _numberState, Point _stateLocationOrigem)
        {
            bool indice = false;

            for (int i = 0; i < 50; i++)
            {
                if (IndiceMatriz[i] != -1)
                {
                    indice = true;
                    break;
                }
            }

            if (indice)
            {
                for (int i = 0; i < 50; i++)
                {
                    for (int j = 0; j < 50; j++)
                    {
                        if (transitionMatrix[i, j] != null)
                        {
                            if (transitionMatrix[i, j].numberStateOrigem == _numberState)
                            {
                                transitionMatrix[i, j].stateLocationOrigem = _stateLocationOrigem;
                                transitionMatrix[i, j].locationStateLabelTransition();
                            }
                            if (transitionMatrix[i, j].numberStateDestino == _numberState)
                            {
                                transitionMatrix[i, j].stateLocationDestino = _stateLocationOrigem;
                                transitionMatrix[i, j].locationStateLabelTransition();
                            }
                            if (_numberState == stateInicial.getNumberState)
                            {
                                stateInicial.getStateLocation = _stateLocationOrigem;
                            }
                        }
                    }
                }
            }

            DrawTransition();
        }
        #endregion

        #region Enabled LabelCompiler
        public void enabledLabelTransition(bool _enabled)
        {
            for (int i = 0; i < 50; i++)
            {
                if (IndiceMatriz[i] != -1)
                {
                    for (int j = 0; j < 50; j++)
                    {
                        if(transitionMatrix[IndiceMatriz[i], j] != null)
                            transitionMatrix[IndiceMatriz[i], j].enabledLabelTransition = _enabled;
                    }                                        
                }
            }
        }
        #endregion

        #region TRANSFORMAÇÕES
   
        #region Ɛ-Closure
        private string Ɛ_Closure(int _state)
        {
            string states = "";
            
            statesƐ.Clear();

            statesƐ = findStates_Ɛ_Closure(_state);

            for (int i = 0; i < statesƐ.Count; i++)
            {
                states += component.getImageState(Convert.ToInt32(statesƐ[i].ToString())).getNameAutomato();
                states += ", ";
            }

            states = states.Remove(states.Length - 2);
            component.getFindIndex().lbTransAFND_AFD.Items.Add("Ɛ-Closure(" + component.getImageState(_state).getNameAutomato() + "): {" + states + "}");

            return states;
        }
        #endregion

        #region Transformacoes
        public void Transformation()
        {
            int stateAtual = getNumberStateInicial();
            string states = Ɛ_Closure(stateAtual);
            bool indiceState = false;
            ;
            
            for (int i = 0; i < countMatrix; i++)
            {
                stateMatrix[i] = null;                
            }            
            
            stateMatrix[countMatrix] = new StatesMatrix();
            stateMatrix[countMatrix].nroState = countMatrix;
            stateMatrix[countMatrix].nameState = states;
            stateMatrix[countMatrix].locationState = component.getImageState(stateAtual).getLocationImage();
            stateMatrix[countMatrix].statesƐ_Closure = statesƐ;
            countMatrix++;

            for (int i = 0; IndiceMatriz[i] != -1; i++)
            {
                ArrayList statesNext = findStateDestinoMatrix(stateAtual);

                for (int k = 0; k < statesNext.Count; k++)
                {
                    stateAtual = Convert.ToInt32(statesNext[k].ToString());

                    for (int j = 0; j < countMatrix; j++)
                    {
                        if (stateMatrix[i] != null &&
                            stateMatrix[i].nroState == stateAtual)
                        {
                            indiceState = true;
                            break;
                        }
                    }
                    if (!indiceState)
                    {
                        states = Ɛ_Closure(stateAtual);

                        stateMatrix[countMatrix] = new StatesMatrix();
                        stateMatrix[countMatrix].nroState = countMatrix;
                        stateMatrix[countMatrix].nameState = states;
                        stateMatrix[countMatrix].locationState = component.getImageState(stateAtual).getLocationImage();
                        stateMatrix[countMatrix].statesƐ_Closure = statesƐ;
                        countMatrix++;
                    }
                }
            }
                        
            for (int i = 0; i < 50; i++)
            {
                if (stateMatrix[i] != null)                    
                {
                    ArrayList statesƐ_Closure = stateMatrix[i].statesƐ_Closure;

                    for (int j = 0; j < statesƐ_Closure.Count; j++)
                    {
                        findStates_Moviment(stateMatrix[i].nroState, Convert.ToInt32(statesƐ_Closure[j].ToString()));
                    }                    
                }//TODO: verificar o erro dado ate aqui
            }
        }
        #endregion

        #region Busca Ɛ_Closure
        public ArrayList findStates_Ɛ_Closure(int _numberState)
        {
            string value;

            ArrayList statesƐ = new ArrayList();
            statesƐ.Add(_numberState);
                        
            for (int i = 0; i < 50; i++)
            {
                if (transitionMatrix[_numberState, i] != null)
                {
                    value = transitionMatrix[_numberState, i].stateValueTransition;
                    
                    for (int j = 0; j < value.Length; j++)
                    {
                        if (value[j] == 'ɛ')
                        {
                            statesƐ.Add(transitionMatrix[_numberState, i].numberStateDestino);
                            break;
                        }
                    }
                }
            }
            return statesƐ;
        }
        #endregion

        #region Busca Moviment
        public void findStates_Moviment(int _stateCreated,int _numberState)
        {            
            string value;
            int numberStateDestino = -1;

            for (int i = 0; i < 50; i++)
            {
                if (transitionMatrix[_numberState, i] != null)
                {         
                    value = transitionMatrix[_numberState, i].stateValueTransition;

                    for (int j = 0; j < value.Length; j++)
                    {
                        if (value[j] != 'ɛ')
                        {
                            numberStateDestino = transitionMatrix[_numberState, i].numberStateDestino;
                            statesMoviment.Add(numberStateDestino);

                            insertNewMatrix(_stateCreated, numberStateDestino,value[j].ToString());
                        }
                    }
                }            
            }
        }
        #endregion

        #region Insere Nova Matriz de Transições
        private void insertNewMatrix(int _stateOrigem, int _stateDestino, string nameTrans)
        {
            bool existStateDestino = false;

            for (int i = 0; i < 50; i++)
            {
                if (stateMatrix[i] != null)
                {
                    ArrayList statesƐ_Closure = stateMatrix[i].statesƐ_Closure;

                    for (int j = 0; j < statesƐ_Closure.Count; j++)
                    {
                        if (Convert.ToInt32(statesƐ_Closure.ToString()) == _stateDestino)
                        {
                            _stateDestino = stateMatrix[i].nroState;
                            existStateDestino = true;
                            break;
                        }
                    }
                }
                if (existStateDestino)
                    break;
            }

            if (existStateDestino)
            {
                if (newTransitionmatrix[_stateOrigem, _stateDestino] == null)
                {
                    newTransitionmatrix[_stateOrigem, _stateDestino] = new TransitionMatrix(component.getFindIndex());
                    newTransitionmatrix[_stateOrigem, _stateDestino].numberStateOrigem = _stateOrigem;
                    newTransitionmatrix[_stateOrigem, _stateDestino].numberStateDestino = _stateDestino;

                    newTransitionmatrix[_stateOrigem, _stateDestino].stateTypeAutomato = TypeAutomato.AFD;

                    bool parmState1 = false, parmState2 = false;

                    for (int i = 0; i < 50; i++)
                    {
                        if (stateMatrix[i] != null)
                        {
                            if (stateMatrix[i].nroState == _stateOrigem && !parmState1)
                            {
                                newTransitionmatrix[_stateOrigem, _stateDestino].stateLocationOrigem = stateMatrix[i].locationState;
                                newTransitionmatrix[_stateOrigem, _stateDestino].stateNameOrigem = stateMatrix[i].nameState;
                            }
                            if (stateMatrix[i].nroState == _stateDestino && !parmState2)
                            {
                                newTransitionmatrix[_stateOrigem, _stateDestino].stateLocationDestino = stateMatrix[i].locationState;
                                newTransitionmatrix[_stateOrigem, _stateDestino].stateNameDestino = stateMatrix[i].nameState;
                            }
                            if (parmState1 && parmState2)
                                break;
                        }
                    }
                    newTransitionmatrix[_stateOrigem, _stateDestino].stateLabelTransition = createImageTransition(nameTrans);
                }
                else
                {
                    newTransitionmatrix[_stateOrigem, _stateDestino].stateLabelTransition = createImageTransition(nameTrans, newTransitionmatrix[_stateOrigem, _stateDestino].stateLabelTransition);
                }
                
            }
        }
        #endregion
        
        #region Cria Label
        public Label createImageTransition(string nameTrans, Label LabelTrans = null)
        {
            if (LabelTrans == null)
            {
                LabelTrans = new Label();
                LabelTrans.Text = nameTrans;
                LabelTrans.Name = nameTrans;
                LabelTrans.ForeColor = Color.Black;
                LabelTrans.BackColor = Color.White;
                LabelTrans.TabIndex = 0;
                LabelTrans.AutoSize = true;
                LabelTrans.Font = new Font("Arial", 9);
            }
            else
            {
                LabelTrans.Text += nameTrans;
            }
            return LabelTrans;
        }
        #endregion

        #endregion

        #region Valida o txtValues
        public bool validateTxtValues(string _values)
        {
            bool ret = false;
            ArrayList valuesCompiler = new ArrayList();

            clearArrayAnime();

            foreach (char c in _values.ToCharArray())
                valuesCompiler.Add(c);

            for (int i = 0; (i < valuesCompiler.Count) && (i < 200); i++)
            {
                valueAnimation[i] = Convert.ToChar(valuesCompiler[i].ToString());
            }

            for (int i = 0; i < valuesCompiler.Count; i++)
            {
                string aux = valuesCompiler[i].ToString();

                for (int j = 0; j < valuesCompiler.Count; j++)
                {
                    if (aux != valuesCompiler[j].ToString())
                        ret = false;
                    else
                    {
                        ret = true;
                        break;
                    }
                }
            }
            return ret;
        }
        #endregion

        #region Botao Compilar
        public void compilar()
        {
            while (!build)
            {
                animarCompilador();
            }
            if (compiler && !anime)
            {
                cancelaCompiler();
                component.getFindIndex().txtValueEntrada.Enabled = true;
                component.getFindIndex().btAnimarPassoAPasso.Enabled = true;
                component.getFindIndex().btCompilar.Enabled = true;
                component.getFindIndex().btFechar.Enabled = true;
            }
        }
            
            
        #endregion

        #region verifica os estados
        public int validateStatesCompilador(int _numberState, char _value)
        {
            string value;
            for (int i = 0; i < 50; i++)
            {
                if (transitionMatrix[_numberState, i] != null)
                {
                    value = transitionMatrix[_numberState, i].stateValueTransition;

                    component.getFindIndex().lbStates.Items.Add(transitionMatrix[_numberState, i].stateNameOrigem);

                    for (int j = 0; j < value.Length; j++)
                    {
                        if (_value == value[j])
                        {
                            nameStateTransition = transitionMatrix[_numberState, i].stateNameDestino;
                            return transitionMatrix[_numberState, i].numberStateDestino;
                        }
                    }
                }
            }
            return -1;
        }
        #endregion

        #region apaga stringValues
        private void clearArrayAnime()
        {
            for (int i = 0; i < 200; i++)
            {
                valueAnimation[i] = ' ';
            }
        }
        #endregion

        #region apaga StateMatrix
        private void clearStateMatrix()
        {
            for (int i = 0; i < 50; i++)
            {
                stateMatrix[i] = null;
            }
        }
        #endregion

        #region Animar Next

        #region AnimarNext Animar
        public void animarCompilador()
        {
            if (!animeInicial && !animeTrans && !animeState)
            {
                animarStateInicial();
            }
            else if ((animeInicial && !animeTrans) && (animeState || animeTransInicial))
            {
                animarTransition(nroStateAtual);
                                
                animeTrans = true;
                animeState = false;
            }
            else if (animeInicial && animeTrans && !animeState)
            {
                animarState(nroStateAtual);
                animeTrans = false;
                animeState = true;
            }
            if (build && anime)
            {
                cancelaCompiler();
                component.getFindIndex().txtValueEntrada.Enabled = true;
                component.getFindIndex().btAnimarPassoAPasso.Enabled = true;
                component.getFindIndex().btCompilar.Enabled = true;
                component.getFindIndex().btFechar.Enabled = true;
            }
        }
        #endregion

        #region AnimarNext StateInicial
        public void animarStateInicial()
        {
            nroStateAtual = stateInicial.getNumberState;
            animeInicial = true;
            animeTransInicial = true;

            component.getImageState(nroStateAtual).corStateMouse(Color.Yellow);
            component.getFindIndex().lbStates.Items.Add(component.getImageState(nroStateAtual).getNameAutomato());
        }
        #endregion

        #region AnimarNext TransicaoState
        public void animarTransition(int number)
        {
            string value;
            component.getImageState(number).corStateMouse(Color.SkyBlue);

            for (int i = 0; i < 50; i++)
            {
                if (transitionMatrix[number, i] != null)
                {
                    value = transitionMatrix[number, i].stateValueTransition;
                    
                    for (int j = 0; j < value.Length; j++)
                    {
                        if (valueAnimation[0] == value[j])
                        {
                            if (animeState)
                            {
                                component.getFindIndex().lbStates.Items.Add(transitionMatrix[number, i].stateNameOrigem);
                            }
                            component.getFindIndex().lbValueTrans.Items.Add(valueAnimation[0]);

                            transitionMatrix[number, i].stateLabelTransition.BackColor = Color.Yellow;

                            component.DrawTransition(transitionMatrix[number, i].stateLocationOrigem,
                                                     transitionMatrix[number, i].stateLocationDestino,
                                                     transitionMatrix[number, i].stateLabelTransition,
                                                     transitionMatrix[number, i].stateTypeTransition,
                                                     TypeDoubleTransition.None,
                                                     Color.Red);
                            nroStateTrans = transitionMatrix[number, i].numberStateDestino;
                            component.addImagePainelAutomato();
                            return;
                            
                        }
                    }
                }
            }
        }
        #endregion
                
        #region AnimarNext State
        public void animarState(int number)
        {
            string value;

            for (int i = 0; i < 50; i++)
            {
                if (transitionMatrix[number, i] != null)
                {
                    value = transitionMatrix[number, i].stateValueTransition;

                    for (int j = 0; j < value.Length; j++)
                    {
                        if (valueAnimation[0] == value[j])
                        {
                            transitionMatrix[number, i].stateLabelTransition.BackColor = Color.Transparent;

                            component.DrawTransition(transitionMatrix[number, i].stateLocationOrigem,
                                                     transitionMatrix[number, i].stateLocationDestino,
                                                     transitionMatrix[number, i].stateLabelTransition,
                                                     transitionMatrix[number, i].stateTypeTransition,
                                                     TypeDoubleTransition.None,
                                                     Color.Black);

                            component.addImagePainelAutomato();
                            component.getFindIndex().lbStatesTransition.Items.Add(transitionMatrix[number, i].stateNameDestino);
                            component.getImageState(nroStateTrans).corStateMouse(Color.Yellow);
                            nroStateAtual = transitionMatrix[number, i].numberStateDestino;
                            deleteValueAnimation(0);

                            if (getFindExistsStateFinal(nroStateAtual) && valueAnimation[0] == ' ')
                            {
                                component.getFindIndex().lblStatusCompiler.Text = "Autômato Aprovado";
                                component.getFindIndex().lblStatusCompiler.ForeColor = Color.Green;
                                component.getFindIndex().lblStatusCompiler.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                                MessageBox.Show(component.getFindIndex().lblStatusCompiler.Text);
                                component.getImageState(nroStateAtual).corStateMouse(Color.SkyBlue);
                                animeInicial = false;
                                animeState = false;
                                animeTrans = false;
                                animeTransInicial = false;
                                component.getFindIndex().txtValueEntrada.Enabled = true;
                                clearArrayAnime();
                                build = true;
                                return;
                            }
                            else if (!getFindExistsStateFinal(nroStateAtual) && valueAnimation[0] == ' ')
                            {
                                component.getFindIndex().lblStatusCompiler.Text = "Autômato Reprovado";
                                component.getFindIndex().lblStatusCompiler.ForeColor = Color.Red;
                                component.getFindIndex().lblStatusCompiler.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                                MessageBox.Show(component.getFindIndex().lblStatusCompiler.Text);
                                component.getImageState(nroStateAtual).corStateMouse(Color.SkyBlue);
                                animeInicial = false;
                                animeState = false;
                                animeTrans = false;
                                animeTransInicial = false;
                                component.getFindIndex().txtValueEntrada.Enabled = true;
                                clearArrayAnime();
                                build = true;
                                return;
                            }                            
                        }
                        else if (!getFindExistsStateFinal(nroStateAtual) && valueAnimation[0] == ' ')
                        {
                            component.getFindIndex().lblStatusCompiler.Text = "Autômato Reprovado";
                            component.getFindIndex().lblStatusCompiler.ForeColor = Color.Red;
                            component.getFindIndex().lblStatusCompiler.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                            MessageBox.Show(component.getFindIndex().lblStatusCompiler.Text);
                            component.getImageState(nroStateAtual).corStateMouse(Color.SkyBlue);
                            animeInicial = false;
                            animeState = false;
                            animeTrans = false;
                            animeTransInicial = false;
                            component.getFindIndex().txtValueEntrada.Enabled = true;
                            clearArrayAnime();
                            build = true;
                            return;
                        }

                    }
                }
            }
            if (getFindExistsStateFinal(nroStateAtual) && valueAnimation.Length == 0)
            {
                animeTrans = false;
                animeInicial = false;
                animeState = false;
            }
        }
        #endregion

        #endregion

        #region Apagar Valor da entrada
        private void deleteValueAnimation(int i)
        {
            if (valueAnimation[i + 1] != ' ')
            {
                char swap = valueAnimation[i];
                valueAnimation[i] = valueAnimation[i + 1];
                valueAnimation[i + 1] = swap;
                deleteValueAnimation(i + 1);
            }
            else
            {
                valueAnimation[i] = ' ';
            }
        }
        #endregion
                
        #endregion
    }
}