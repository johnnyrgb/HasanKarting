import React, { useEffect, useState } from "react";
import { Input, Modal, Button, Form } from "antd";
import CarObj from "../Entities/CarObj";
// import { editableInputTypes } from "@testing-library/user-event/dist/utils";

interface PropsType {
    editingCar: CarObj | undefined;
    addCar: (car: CarObj) => void;
    updateCar: (car: CarObj) => void;
    createModalIsShow: boolean;
    showCreateModel: (car: boolean) => void;
}

const CarCreate : React.FC<PropsType> = ({
    editingCar,
    addCar,
    updateCar,
    createModalIsShow, 
    showCreateModel
}) => {
    const [form] = Form.useForm();
    const [manufacturer, setManufacturer] = useState<string>("");
    const [model, setModel] = useState<string>("");
    const [power, setPower] = useState<number>();
    const [mileage, setMileage] = useState<number>();
    const [weight, setWeight] = useState<number>();
    const [isEdit, setIsEdit] = useState<boolean>(false);

    useEffect(() => {

        if (editingCar !== undefined)
        {
            form.setFieldsValue({
                manufacturer: editingCar.manufacturer,
                model: editingCar.model,
                power: editingCar.power,
                mileage: editingCar.mileage,
                weight: editingCar.weight,
            });
            setManufacturer(editingCar.manufacturer);
            setModel(editingCar.model);
            setPower(editingCar.power);
            setMileage(editingCar.mileage);
            setWeight(editingCar.weight);
            console.log(editingCar.manufacturer)
            setIsEdit(true);
        }

        return () => {
            form.resetFields();
            setIsEdit(false);
        }
    }, [editingCar, form]);

    const handleSubmit = (e: Event) => {
        const createCompanies = async () => {
            const car : CarObj = {
                manufacturer: String(),
                model: String(),
                power: Number(),
                mileage: Number(),
                weight: Number(),
            }

            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(car)
            };

            const response = await fetch(`http://localhost:7083/api/Companies`, requestOptions);
            return await response.json()
                .then((data) => {
                    console.log(data)
                    if (response.ok) {
                        addCar(data);
                        form.resetFields();
                    }
                },
                (error) => console.log(error)
                );
        };
        const editCars = async (id: number | undefined) => {
            const car: CarObj = {
                id,
                manufacturer: String(),
                model: String(),
                power: Number(),
                mileage: Number(),
                weight: Number()
            }
    
            const requestOptions = {
                method: "PUT",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(car)
            };

            const response = await fetch(`http://localhost:7083/api/Cars/${id}`, requestOptions);
            await response.json()
                .then(
                    (data) => {
                        if (response.ok) {
                            console.log(data)
                            updateCar(data);
                            setIsEdit(false);
                            form.resetFields();
                        }
                    },
                    (error) => console.log(error)
                );
        };
        if (isEdit)
        {
            console.log(editingCar);
            editCars(editingCar?.id);
        }
        else createCompanies();
    };

    return (
        <Modal open={createModalIsShow}
            title="А-а-а-автомобиль"
            onCancel={() => showCreateModel(false)}
            footer={[
                <Button
                    key="submitButton"
                    form="carForm"
                    type="primary"
                    htmlType="submit"
                    onClick={() => showCreateModel(false)}>
                    Save
                </Button>,
                <Button key="closeButton" onClick={() => showCreateModel(false)} danger>
                    Close
                </Button>
            ]}>
            <Form id="carForm" onFinish={handleSubmit} form={form}>
                <Form.Item name="manufacturer" label="Производитель" hasFeedback rules={[
                    {
                        required: true,
                        type: "string",
                        message: "Введите название произоводителя"
                    }
                ]}>
                    <Input
                        key="manufacturerInput"
                        type="text"
                        name="manufacturerInput"
                        placeholder=""
                        value={manufacturer}
                        onChange={(e) => setManufacturer(e.target.value)} />
                </Form.Item>
                <Form.Item name="model" label="Модель" hasFeedback rules={[
                    {
                        required: true,
                        type: "string",
                        message: "Введите модель"
                    }
                ]}>
                    <Input
                        key="modelInput"
                        type="text"
                        name="modelInput"
                        placeholder=""
                        value={model}
                        onChange={(e) => setModel(e.target.value)} />
                </Form.Item>
                <Form.Item name="power" label="Мощность" hasFeedback rules={[
                    {
                        required: true,
                        type: "number",
                        message: "Введите мощность"
                    }
                ]}>
                    <Input
                        key="powerInput"
                        type="number"
                        name="modelInput"
                        placeholder=""
                        value={power}
                        onChange={(e) => setModel(e.target.value)} />
                </Form.Item>
                <Form.Item name="mileage" label="Километраж" hasFeedback rules={[
                    {
                        required: true,
                        type: "number",
                        message: "Введите километраж"
                    }
                ]}>
                    <Input
                        key="mileageInput"
                        type="number"
                        name="mileageInput"
                        placeholder=""
                        value={mileage}
                        onChange={(e) => setModel(e.target.value)} />
                </Form.Item>
                <Form.Item name="weight" label="Масса" hasFeedback rules={[
                    {
                        required: true,
                        type: "number",
                        message: "Введите массу"
                    }
                ]}>
                    <Input
                        key="weightInput"
                        type="number"
                        name="weightInput"
                        placeholder=""
                        value={weight}
                        onChange={(e) => setModel(e.target.value)} />
                </Form.Item>
            </Form>
        </Modal>
    );
};

export default CarCreate;