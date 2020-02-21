import React from 'react';
import { LandingPage } from './LandingPage';
import { ThemeProvider, CssBaseline } from '@material-ui/core';
import { theme } from './styles/theme';
import { LogIn } from './LogIn';
import { Register } from './Register';
import { Route, withRouter } from 'react-router-dom';

const App = () => {
  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Route exact path="/" component={LandingPage} />
      <Route exact path="/login" component={LogIn} />
      <Route exact path="/register" component={Register} />
    </ThemeProvider>
  );
};

export default withRouter(App);
