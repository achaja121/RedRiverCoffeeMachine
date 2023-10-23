import './App.css';
import { ChakraProvider } from '@chakra-ui/react'
import Header from './components/Header/Header';
import DrinksChoice from './components/DrinksChoice/DrinksChoice';

function App() {
  return (
    <div className="App">
      <ChakraProvider>
      <Header/>
      <DrinksChoice/>
      </ChakraProvider>
    </div>
  );
}

export default App;
