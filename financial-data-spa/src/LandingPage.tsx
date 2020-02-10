import React from 'react';
import clsx from 'clsx';
import { Box, WithStyles, withStyles, Button } from '@material-ui/core';

interface IProps extends WithStyles<typeof styles> {
  children?: React.ReactNode;
  className?: string;
}

const styles = {
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
    margin: '0 1rem 0 1rem',
    '&:hover': {
      background: '#fff',
      color: '#2b3b50'
    }
  }
};

const LandingPage = (props: IProps) => {
  const { classes, children, className, ...other } = props;

  return (
    <Box className={clsx(classes.root, className)} {...other}>
      <Box
        style={{ height: '100%' }}
        display="flex"
        flexDirection="column"
        justifyContent="center"
        alignItems="center"
      >
        <Box display="flex" alignItems="center">
          <Box>
            <img
              className={clsx(classes.logo, className)}
              {...other}
              src="../assets/value_up_icon_white.png"
              alt="Company Logo"
            ></img>
          </Box>
          <Box className={clsx(classes.headerText, className)} {...other}>
            <h1>FinancialData</h1>
          </Box>
        </Box>
        <Box display="flex" alignItems="center">
          <Button
            variant="outlined"
            size="large"
            disableRipple={true}
            className={clsx(classes.btn, className)}
            {...other}
          >
            Log In
          </Button>
          <Button
            variant="outlined"
            size="large"
            disableRipple={true}
            className={clsx(classes.btn, className)}
            {...other}
          >
            Register
          </Button>
        </Box>
      </Box>
    </Box>
  );
};

export default withStyles(styles)(LandingPage);
