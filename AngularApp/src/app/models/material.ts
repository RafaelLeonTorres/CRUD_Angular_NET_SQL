export interface Material {
    id: number;
    name: string;
    description: string;
}

export interface MaterialCreateDTO {
    name: string;
    description: string;
}

export interface MaterialUpdateDTO {
    name: string;
    description: string;
}