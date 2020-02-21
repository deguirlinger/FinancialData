import React from 'react';
import { Box, TextField, makeStyles, Button } from '@material-ui/core';
import { Link } from 'react-router-dom';

const useStyles = makeStyles({
  root: {
    display: 'flex',
    flexDirection: 'column',
    background: '#2b3b50',
    color: '#fff',
    height: '100vh'
  },
  header: {
    display: 'flex'
  },
  linkStyle: {
    color: 'inherit',
    textDecoration: 'inherit'
  },
  logoLink: {
    display: 'flex',
    marginLeft: '1rem',
    marginTop: '1rem'
  },
  logoImg: {
    alignSelf: 'center',
    width: '1.75rem',
    marginRight: '0.25rem',
    position: 'relative',
    bottom: '2px'
  },
  logoText: {
    margin: 0
  },
  content: {
    height: '100%',
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center'
  },
  formContainer: {
    textAlign: 'center',
    width: '300px',
    position: 'relative',
    bottom: '5%'
  },
  inputField: {
    '& .MuiOutlinedInput-root .MuiOutlinedInput-notchedOutline': {
      border: '#fff solid 2px'
    },
    '&:hover .MuiOutlinedInput-root .MuiOutlinedInput-notchedOutline': {
      border: '#bc871e solid 2px'
    },
    '& .MuiOutlinedInput-root.Mui-focused .MuiOutlinedInput-notchedOutline': {
      border: '#bc871e solid 2px'
    },
    '& .MuiOutlinedInput-input': {
      color: '#fff'
    },
    '& label': {
      color: '#fff'
    },
    '& label.Mui-hover': {
      color: '#bc871e'
    },
    '& label.Mui-focused': {
      color: '#bc871e'
    },
    marginBottom: '1.5rem'
  },
  btn: {
    border: '2px solid #fff',
    background: '#fff',
    color: '#2b3b50',
    '&:hover': {
      border: '2px solid #bc871e',
      background: '#bc871e',
      color: '#2b3b50'
    }
  }
});

export const LogIn = () => {
  const classes = useStyles();

  return (
    <div className={classes.root}>
      <Box className={classes.header}>
        <Link to={'/'} className={classes.linkStyle}>
          <Box className={classes.logoLink}>
            <img
              src="../assets/value_up_icon_white.png"
              alt="Company Logo"
              className={classes.logoImg}
            />
            <h1 className={classes.logoText}>FinancialData</h1>
          </Box>
        </Link>
      </Box>
      <Box className={classes.content}>
        <form className={classes.formContainer}>
          <h2>Log In</h2>
          <div>
            <TextField
              className={classes.inputField}
              required
              id="email"
              type="email"
              label="Email"
              variant="outlined"
              fullWidth={true}
            />
          </div>
          <div>
            <TextField
              className={classes.inputField}
              required
              id="password"
              type="password"
              label="Password"
              variant="outlined"
              fullWidth={true}
            />
          </div>
          <div>
            <Button
              variant="outlined"
              size="large"
              disableRipple={true}
              className={classes.btn}
              fullWidth={true}
            >
              Log In
            </Button>
          </div>
        </form>
      </Box>
    </div>
  );
};
