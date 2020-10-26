declare module 'react-cropper'{
    import * as cropperjs from 'cropperjs';
    import * as React from 'react';

    type Omit<T, K> = Pick<T, Exclude<keyof T, K>>;

    export interface ReactCropperProps extends cropperjs.CropperOptions, Omit<React.HTMLProps<HTMLImageElement>, 'data' | 'ref'> {
        ref?: string | React.RefObject<Cropper> | ((cropper: null | ReactCropper) => any);
        aspectRatio: number;
        preview: string;
        guides: boolean;
        crop: function;
        viewMode:number;
        dragMode: string;
        scalable: boolean;
        cropBoxMovable: boolean;
        cropBoxResizable: boolean;  
    }

    interface ReactCropper extends cropperjs {} // tslint:disable-line no-empty-interface
    declare class ReactCropper extends React.Component<ReactCropperProps> {
        on(eventname: string, callback: () => void): void;
    }
    export default ReactCropper;
}
