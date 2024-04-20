import { Events } from "./Events";
import { Speaker } from "./Speaker";

export interface SpeakerEvent{
    eventId: number;
    event: Events;
    speakerId: number;
    speaker: Speaker;

}