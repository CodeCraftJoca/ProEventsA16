import { Batch } from "./Batch";
import { SocialNetwork } from "./SocialNetwork";
import { SpeakerEvent } from "./SpeakerEvent";

export interface Events {
    id: number;
    local: string;
    eventDate?: Date;
    theme: string;
    numberOfPeople: number;
    imgUrl: string;
    telephone: string;
    email: string;
    batch: Batch[];
    socialNetwork: SocialNetwork[];
    speakerEvents: SpeakerEvent[];
}