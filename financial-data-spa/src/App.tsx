import React from 'react';
import LandingPage from './LandingPage';
import { ThemeProvider, CssBaseline } from '@material-ui/core';
import { theme } from './styles/theme';

const App = () => {
  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <LandingPage />
    </ThemeProvider>
  );
};

export default App;
