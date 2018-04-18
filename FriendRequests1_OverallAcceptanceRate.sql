/**************************************************************************
#597. Friend Requests I: Overall Acceptance Rate
#Write your MySQL query statement below
#select IFNULL(cast((sum(case when a.accepter_id > 0 then 1 else 0 end) / count(*)) as decimal (10,2)), 0.00) as accept_rate
#from (select distinct sender_id, send_to_id from friend_request) r
#left join (select distinct requester_id, accepter_id from request_accepted) a on r.sender_id = a.requester_id and r.send_to_id = a.accepter_id;
**************************************************************************/
select
round(
    ifnull(
    (select count(*) from (select distinct requester_id, accepter_id from request_accepted) as A)
    /
    (select count(*) from (select distinct sender_id, send_to_id from friend_request) as B),
    0)
, 2) as accept_rate;