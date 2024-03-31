import { BrowserRouter, Route, Routes } from 'react-router-dom';
import React from 'react';
import './App.css';
import Cars from './Components/Cars/Cars';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route index element={<h3>Картинг-центр "Hasan Karting"</h3>}/>
        <Route path='/cars' element={<Cars/>}/>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
