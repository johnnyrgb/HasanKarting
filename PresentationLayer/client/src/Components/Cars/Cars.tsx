import React, {useState, useEffect} from "react";
import {Button, Table} from "antd";
import type { TableProps } from "antd";
import CarObj from "../Entities/CarObj";
import CarCreate from "./CarCreate";

// import CarCreate

interface PropsType { }

const Car : React.FC<PropsType> = () => {
    const [cars, setCars] = useState<Array<CarObj>>([]);
    const [createModalIsShow, showCreateModel] = useState<boolean>(false);
    const [editingCar, setEditingCar] = useState<CarObj>();

    const removeCar = (removeId: number | undefined) => setCars(cars.filter(({ id }) => id !== removeId));

    const updateCompanies = (car : CarObj) => {
        setCars(
            cars.map((e) => {
                if (e.id === car.id)
                    return car;
                return e;
            })
        )
    };

    const addCar = (car : CarObj) => setCars([...cars, car]);

    useEffect(() => {
        const getCars = async () => {

            const requestOptions: RequestInit = {
                method: 'GET'
            };

            await fetch(`http://localhost:5075/api/Cars`, requestOptions)
                .then(response => response.json())
                .then(
                    (data) => {
                        console.log(data);
                        setCars(data);
                    },
                    (error) => console.log(error)
                );
        };
        getCars();
    }, [createModalIsShow]);

    const deleteCar = async (id: number | undefined) => {
        const requestOptions: RequestInit = {
            method: 'DELETE'
        }

        return await fetch(`http://localhost:5075/api/Cars/${id}`, requestOptions)
            .then((response) => {
                if (response.ok) {
                    removeCar(id);
                    console.log(id);
                }
            },
                (error) => console.log(error)
            )
    };

    const editCar = (obj : CarObj) => {
        setEditingCar(obj);
        console.log(obj)
        showCreateModel(true);
    };

    const columns : TableProps<CarObj>["columns"] = [
        {
            title: "Название компании",
            dataIndex: "manufacturer",
            key: "manufacturer",
        },
        {
            key: "Delete",
            render: (row : CarObj) => (
                <Button key="deleteButton"
                        type="primary"
                        onClick={() => deleteCar(row.id)}
                        danger>
                            Удалить
                </Button>
            ),
        },
        {
            key: "Edit",
            render: (row : CarObj) => (
                <Button key="editButton"
                        type="primary"
                        onClick={() => editCar(row)}>
                            Изменить
                </Button>
            ),
        }
    ];
    return (
        <React.Fragment>
            <CarCreate
                editingCar={editingCar}
                addCar={addCar}
                updateCar={updateCompanies}
                createModalIsShow={createModalIsShow}
                showCreateModel={showCreateModel}
            />
            <Button onClick={(e) => showCreateModel(true)}>Добавить компанию</Button>
            <Table
                key="CompaniesTable"
                dataSource={cars}
                columns={columns}
                pagination={{pageSize: 15}}
                scroll={{y: 1000}}
                bordered
            />
        </React.Fragment>
    )
}

export default Car;