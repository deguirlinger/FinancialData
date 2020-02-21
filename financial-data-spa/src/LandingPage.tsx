import React from 'react';
import { Box, Button, makeStyles, Container } from '@material-ui/core';
import { Link } from 'react-router-dom';

const useStyles = makeStyles({
  root: {
    display: 'flex',
    background: '#2b3b50',
    color: '#fff',
    height: '100vh'
  },
  content: {
    height: '100%',
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
    justifyContent: 'center'
  },
  logo: {
    display: 'flex',
    position: 'relative',
    right: '2px'
  },
  logoImg: {
    alignSelf: 'center',
    width: '2rem',
    marginRight: '0.25rem',
    position: 'relative',
    bottom: '2px'
  },
  logoText: {
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
      <Container>
        <Box className={classes.content}>
          <Box className={classes.logo}>
            <img
              className={classes.logoImg}
              src="../assets/value_up_icon_white.png"
              alt="Company Logo"
            ></img>
            <h1 className={classes.logoText}>FinancialData</h1>
          </Box>
          <Box>
            <Button
              component={Link}
              to={'/login'}
              variant="outlined"
              size="large"
              disableRipple={true}
              className={classes.btn}
            >
              Log In
            </Button>
            <Button
              component={Link}
              to={'/register'}
              variant="outlined"
              size="large"
              disableRipple={true}
              className={classes.btn}
            >
              Register
            </Button>
          </Box>
        </Box>
      </Container>
    </div>
  );
};
