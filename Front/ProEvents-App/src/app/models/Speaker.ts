import { SocialNetwork } from "./SocialNetwork";
import { SpeakerEvent } from "./SpeakerEvent";

export interface Speaker {
    id: number;
    name: string;
    bio: string;
    imgUrl: string;
    telephone: string;
    email: string;
    socialNetwork: SocialNetwork[];
    speakerEvents: SpeakerEvent[];
}
