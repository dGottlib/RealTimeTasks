import React, { useState, useRef, useEffect } from 'react';
import { UseAuthorizeDataContext } from '../AuthorizeContext';
import { HubConnectionBuilder } from '@microsoft/signalr';

const Home = () => {
    const { user } = UseAuthorizeDataContext();
    const [tasks, setTasks] = useState([]);
    const [title, setTitle] = useState('');

    const connectionRef = useRef(null);

    useEffect(() => {
        const connectToHub = async () => {
            const connection = new HubConnectionBuilder().withUrl("/task").build();
            await connection.start();

            connectionRef.current = connection;

            connectionRef.current.invoke('getTasks');

            connection.on('getTasks', tasks => {
                setTasks(tasks)
            });;

                connection.on('addTask', tasks => {
                    setTasks(tasks);
                });

                connection.on('markAsDoing', tasks => {
                    setTasks(tasks);
                });

                connection.on('markAsDone', tasks => {
                    setTasks(tasks);
                }) 
           
        }

        connectToHub();
       
    }, []);

    const onFormSubmit = async e => {
        e.preventDefault();
        connectionRef.current.invoke('addTask', title);
        setTitle('');
    }

    const onDoingClick = async (task) => {
        connectionRef.current.invoke('markAsDoing', task);
    }

    const onDoneClick = async (task) => {
        connectionRef.current.invoke('markAsDone', task)
    }

    console.log(tasks)

    return (
        <div className="container" style={{ marginTop: '60px' }}>
            <div style={{ marginTop: '70px' }}>
                <form onSubmit={onFormSubmit}>
                    <div className="row">
                        <div className="col-md-10">
                            <input type="text" className="form-control" onChange={e => setTitle(e.target.value)} placeholder="Task Title" value={title} />
                        </div>
                        <div className="col-md-2">
                            <button className="btn btn-primary btn-block">Add Task</button>
                        </div>
                    </div>
                </form>

                <table className="table table-hover table-striped table-bordered mt-3">
                    <thead>
                        <tr>
                            <th>Title</th>
                            <th>Status</th>
                        </tr>
                    </thead>
                    <tbody>
                        {tasks && tasks.map(t => <tr key={t.id}>
                            <td>{t.title}</td>
                            <td>
                                {t.status === 0 && <button className='btn btn-info' onClick={()=>onDoingClick(t)}>I'm doing this one!</button>}
                                {((t.status === 1) && t.user.id !== user.id) && <button className='btn btn-warning' disabled> {t.user.firstName} {t.user.lastName} is doing this</button>}
                                {((t.status === 1) && t.user.id === user.id) && <button className='btn btn-success' onClick={()=>onDoneClick(t)}>I'm done!</button>}
                            </td>
                        </tr>)}
                    </tbody>
                </table>
            </div>
        </div >
    )
}

export default Home;