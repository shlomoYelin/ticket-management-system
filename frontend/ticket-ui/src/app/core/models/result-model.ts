export interface ResultModel<T> {
    success: boolean;
    errorMessage?: string;
    data: T;
}
