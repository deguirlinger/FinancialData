import React from 'react';
import { Box, TextField, makeStyles, Button } from '@material-ui/core';

const useStyles = makeStyles({
  root: {
    background: '#2b3b50',
    color: '#fff',
    height: '100vh'
  },
  header: {
    marginLeft: '1rem',
    display: 'flex',
    flexDirection: 'row',
    alignItems: 'center'
  },
  logo: {
    width: '1.75rem',
    marginRight: '0.25rem'
  },
  formContainer: {
    width: '300px'
  },
  content: {
    height: '100%',
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center',
    flexDirection: 'column',
    position: 'relative',
    bottom: '90px'
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
    color: '#fff',
    '&:hover': {
      background: '#fff',
      color: '#2b3b50'
    }
  }
});

export const LogIn = () => {
  const classes = useStyles();

  return (
    <div className={classes.root}>
      <Box className={classes.header}>
        <div>
          <img
            src="../assets/value_up_icon_white.png"
            alt="Company Logo"
            className={classes.logo}
          />
        </div>
        <div>
          <h1>FinancialData</h1>
        </div>
      </Box>
      <Box className={classes.content}>
        <h2>Log In</h2>
        <form className={classes.formContainer}>
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
