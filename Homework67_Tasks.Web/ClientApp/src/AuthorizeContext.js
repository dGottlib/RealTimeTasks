import React, {useState, useEffect, useContext, createContext} from 'react';
import axios from 'axios';

const AuthorizeContext = createContext();

const AuthorizeContextComponent = ({children}) => {
  const [user, setUser] = useState(null);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    const getUser = async () => {
        const {data} = await axios.get('api/account/getcurrentuser');
        setUser(data);
        setIsLoading(false);
    }

    getUser();
  }, [])

  return (
    <AuthorizeContext.Provider value={{user, setUser}}>
        {isLoading ? <span></span> : children}
    </AuthorizeContext.Provider>
  )
}

export const UseAuthorizeDataContext = () => useContext(AuthorizeContext);

export default AuthorizeContextComponent;