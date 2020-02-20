import React from 'react';
import { LandingPage } from './LandingPage';
import { ThemeProvider, CssBaseline } from '@material-ui/core';
import { theme } from './styles/theme';
import { LogIn } from './LogIn';
import { Register } from './Register';

const App = () => {
  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      {/* <LandingPage /> */}
      {/* <LogIn /> */}
      <Register />
    </ThemeProvider>
  );
};

export default App;
