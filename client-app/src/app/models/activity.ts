import { StrictCommentGroupProps } from "semantic-ui-react";

export interface IActivity {
    id: string;
    title: string;
    description: string;
    category: string;
    date: Date;
    city: string;
    venue: string;
}