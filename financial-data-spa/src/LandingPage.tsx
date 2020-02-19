import React from 'react';
import { Box, Button, makeStyles } from '@material-ui/core';

const useStyles = makeStyles({
  root: {
    background: '#2b3b50',
    color: '#fff',
    height: '100vh'
  },
  logo: {
    width: '4rem',
    marginRight: '0.25rem'
  },
  headerText: {
    fontSize: '2rem'
  },
  btn: {
    border: '2px solid #fff',
    color: '#fff',
    margin: '0 0.5rem 0 0.5rem',
    '&:hover': {
      background: '#fff',
      color: '#2b3b50'
    }
  }
});

export const LandingPage = () => {
  const classes = useStyles();

  return (
    <div className={classes.root}>
      <Box
        style={{ height: '100%' }}
        display="flex"
        flexDirection="column"
        justifyContent="center"
        alignItems="center"
      >
        <Box display="flex" alignItems="center">
          <div>
            <img
              className={classes.logo}
              src="../assets/value_up_icon_white.png"
              alt="Company Logo"
            ></img>
          </div>
          <div className={classes.headerText}>
            <h1>FinancialData</h1>
          </div>
        </Box>
        <Box display="flex" alignItems="center">
          <Button
            variant="outlined"
            size="large"
            disableRipple={true}
            className={classes.btn}
          >
            Log In
          </Button>
          <Button
            variant="outlined"
            size="large"
            disableRipple={true}
            className={classes.btn}
          >
            Register
          </Button>
        </Box>
      </Box>
    </div>
  );
};
