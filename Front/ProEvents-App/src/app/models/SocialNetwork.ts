import { Events } from "./Events";
import { Speaker } from "./Speaker";

export interface SocialNetwork {
    id: number;
    name: string;
    url: string;
    eventId?: number;
    event?: Events;
    speakerId?: number;
    speaker?: Speaker;
}
