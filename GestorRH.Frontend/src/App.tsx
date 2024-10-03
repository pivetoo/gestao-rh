import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import './App.css'
import Homepage from './pages/Homepage'
import NotFoundPage from './pages/NotFoundPage'
import { ThemeProvider } from '@emotion/react'
import theme from './theme'

function App() {

  return (
    <ThemeProvider theme={theme}>
      <Router>
        <Routes>
          <Route path='/' element={<Homepage />} />
          <Route path='*' element={<NotFoundPage />} />
        </Routes>
      </Router>
    </ThemeProvider>

  )
}

export default App
