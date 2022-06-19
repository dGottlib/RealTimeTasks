import React, {useEffect} from 'react';
import axios from 'axios';
import { UseAuthorizeDataContext } from '../AuthorizeContext';
import { useHistory } from 'react-router-dom';

const Logout = () => {
  const {setUser} = UseAuthorizeDataContext();
  const history = useHistory();

  useEffect(() => {
    const doLogout = async () => {
      await axios.get('/api/account/logout');
      setUser(null);
      history.push('/login');
    }

    doLogout();
  }, [])

  return(<></>)
}
export default Logout;