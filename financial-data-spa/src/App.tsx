import React from 'react';
import { LandingPage } from './LandingPage';
import { ThemeProvider, CssBaseline } from '@material-ui/core';
import { theme } from './styles/theme';
import { LogIn } from './LogIn';

const App = () => {
  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <LogIn />
      {/* <LandingPage /> */}
    </ThemeProvider>
  );
};

export default App;
